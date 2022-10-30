const DEFAULTFIELDWIDTH = 10;
const DEFAULTFIELDHEIGHT = 10;
const DEFAULTMINECOUNT = 20;
const MINDIMENSIONSIZE = 5;
const MAXDIMENSIONSIZE = 20;
const MAXMINESCOUNT = MAXDIMENSIONSIZE * MAXDIMENSIONSIZE - 1;
const MINERATIO = 0.23;
const MINMINESCOUNT = 5;
let FIELDWIDTH = 0;
let FIELDHEIGHT = 0;
let MINECOUNT = 0;
resetGameParameters();
const MINEMARKER = 'O';
const WRONGMINEMARKER = '<i class="fa-solid fa-ban"></i>';
const CELLWITHNOMINESAROUNDDESIGNATOR = '.';
const SUPPOSEDMINEMARKER = 'X';
const REALMINEMARKERHTMLWHENREVEALED = '<i class="fa-solid fa-asterisk"></i>';
let field = Array.from(Array(FIELDHEIGHT), () => new Array(FIELDWIDTH).fill(CELLWITHNOMINESAROUNDDESIGNATOR));
let map = new Map();
let won = false;
let minesLeft = 0;
let startTime = (new Date).getTime();
let timerIntervalId;
let hintCount = 0;
let penaltyTimeInSeconds = 0;
let secondsInAMinute = 60;
let secondsInAnHour = secondsInAMinute * 60;
let secondsInADay = secondsInAnHour * 24;

class Cell {
    constructor(row, col) {
        this.row = row;
        this.col = col;
    }
}

function resetGameParameters() {
    FIELDWIDTH = DEFAULTFIELDWIDTH;
    FIELDHEIGHT = DEFAULTFIELDHEIGHT;
    MINECOUNT = DEFAULTMINECOUNT;
    setGameParameters([FIELDWIDTH, FIELDHEIGHT, MINECOUNT]);
}

function readGameParameters() {
    let widthInputByUser = determineUserInputAsInt(MINDIMENSIONSIZE, MAXDIMENSIONSIZE, 'playingFieldWidthInput', DEFAULTFIELDWIDTH);
    console.log('Read width input: ', widthInputByUser);
    let heightInputByUser = determineUserInputAsInt(MINDIMENSIONSIZE, MAXDIMENSIONSIZE, 'playingFieldHeightInput', DEFAULTFIELDHEIGHT);
    console.log('Read height input: ', heightInputByUser);

    let appropriateMineCountForTheseDimensions = Math.floor(widthInputByUser * heightInputByUser * MINERATIO);
    let minesAmountInputByUser = determineUserInputAsInt(MINMINESCOUNT, widthInputByUser * heightInputByUser - 1, 'minesAmountInput', appropriateMineCountForTheseDimensions); 
    console.log('read: ' + minesAmountInputByUser);

    return [widthInputByUser, heightInputByUser, minesAmountInputByUser];
}

function setGameParameters(params) {
    FIELDWIDTH = params[0];
    FIELDHEIGHT = params[1];
    MINECOUNT = params[2];

    setInputParameter('playingFieldWidthInput', FIELDWIDTH);
    setInputParameter('playingFieldHeightInput', FIELDHEIGHT);
    setInputParameter('minesAmountInput', MINECOUNT);
    setGameParameterGuards();
}

function determineUserInputAsInt(min, max, fieldName, defaultValue) {
    let userInput = document.getElementById(fieldName).value;
    console.log(`Read ${!userInput ? '_nothing_' : userInput} for field ${fieldName} `);
    let candidate = parseInt(userInput);
    if (!candidate) return defaultValue;
    if (candidate < min) return min;
    if (candidate > max) return max;

    return candidate;
}

function setGameParameterGuards() {
    setMinMaxParameters('minesAmountInput', MINMINESCOUNT, (FIELDHEIGHT * FIELDWIDTH - 1));
}

function setInputParameter(id, val) {
    document.getElementById(id).value = val;
}

function setMinMaxParameters(id, min, max) {
    document.getElementById(id).min = min;
    document.getElementById(id).max = max;
}

document.addEventListener('DOMContentLoaded', function () {
    resetGame();
});

function resetGame() {
    let start = (new Date()).getTime();
    map = new Map();
    won = false;
    penaltyTimeInSeconds = 0;
    setGameParameters(readGameParameters());
    field = Array.from(Array(FIELDHEIGHT), () => new Array(FIELDWIDTH).fill('.'));
    createField();
    calculateMarkers();
    createTable();
    minesLeft = MINECOUNT;
    setMineCountDisplay();
    let nd = new Date;
    startTime = nd.getTime();
    if (!timerIntervalId) {
        timerIntervalId = setInterval(showTimer, 1000);
    }
    hintCount = 0;
    document.getElementById('elapsedTimeString').innerText = '0 seconds.'
    document.querySelectorAll('#playingField td').forEach(el => el.addEventListener('click', clickCell));
    document.querySelectorAll('#playingField td').forEach(el => el.addEventListener('contextmenu', toggleDanger, false));
    document.getElementById('largeHintButton').disabled = !getHintCandidates(true).length;
    document.getElementById('smallHintButton').disabled = false;
    document.getElementById('minesLeft').className = '';
    let end = (new Date()).getTime();
    let diff = end - start;
    console.log('Game is set and ready in ' + diff + ' ms');
}

function getElapsedSeconds() {
    let currentTime = (new Date).getTime();
    return Math.round(Math.floor(currentTime - startTime) / 1000);
}

function getElapsedSecondsAdjustedForPenalties() {
    let secondsElapsedWithoutPenalties = getElapsedSeconds();
    return secondsElapsedWithoutPenalties + penaltyTimeInSeconds;
}

function showTimer() {
    let seconds = getElapsedSecondsAdjustedForPenalties();
    document.getElementById('elapsedTimeString').innerText = formatSecondsIntoTimeString(seconds);
}

function formatSecondsIntoTimeString(secs) {
    let totalDays = Math.floor(secs / secondsInADay);
    let totalHours = Math.floor((secs - totalDays * secondsInADay) / secondsInAnHour);
    let totalMinutes = Math.floor((secs - totalDays * secondsInADay - totalHours * secondsInAnHour) / secondsInAMinute);
    let leftoverSeconds = (secs - totalDays * secondsInADay - totalHours * secondsInAnHour - totalMinutes * secondsInAMinute);

    let ret = '';
    if (totalDays > 0) ret = totalDays.toString() + ' day' + (totalDays > 1 ? 's ' : ' ');
    if (totalHours > 0 || totalHours === 0 && totalDays > 0) ret += totalHours.toString() + ' hour' + (totalHours === 1 ? ' ' : 's ');
    if (totalMinutes > 0 || (totalMinutes === 0 && (totalHours > 0 || totalDays > 0))) ret += totalMinutes.toString() + ' minute' + (totalMinutes === 1 ? ' ' : 's ');
    ret += leftoverSeconds.toString() + ' second' + (leftoverSeconds === 1 ? '' : 's');
    return ret;
}

function createField() {
    let mineCount = MINECOUNT;
    //TODO: stopwatch here
    let start = (new Date()).getTime();

    while (mineCount > 0) {
        rndRow = randomNumber(FIELDHEIGHT);
        rndCol = randomNumber(FIELDWIDTH);
        if (field[rndRow][rndCol] !== MINEMARKER) {
            field[rndRow][rndCol] = MINEMARKER;
            mineCount--;
        }
    }
    let end = (new Date()).getTime();
    let diff = end - start;
    console.log('Field created in ' + diff + ' ms');
}

function calculateMarkers() {
    let start = (new Date()).getTime();
    for (let i = 0; i < field.length; i++) {
        for (let j = 0; j < field[i].length; j++) {
            if (field[i][j] === MINEMARKER) continue;
            let marker = calcFieldMarker(i, j);
            if (marker > 0) {
                field[i][j] = marker.toString();
            }
        }
    }
    let end = (new Date()).getTime();
    let diff = end - start;
    console.log('Field markers calculated in ' + diff + ' ms');
}

function createTable() {

    let start = (new Date()).getTime();
    let container = document.getElementById('tbl');
    container.innerHTML = '';
    let tbl = document.createElement('table');
    tbl.setAttribute('id', 'playingField');
    let tbody = document.createElement('tbody')
    for (let i = 0; i < FIELDHEIGHT; i++) {
        let tr = document.createElement('tr');
        for (let j = 0; j < FIELDWIDTH; j++) {
            let td = document.createElement('td');
            td.setAttribute('data-row', i);
            td.setAttribute('data-col', j);
            td.setAttribute('data-hidden', '1');
            td.setAttribute('data-cell', 'cell-' + i + '-' + j);
            td.setAttribute('data-hint', determineHint(field[i][j]));
            td.classList.add('playingField');

            td.appendChild(document.createTextNode('?'));
            tr.appendChild(td);
            tbody.appendChild(tr);
        }
        tbl.appendChild(tbody);
        container.appendChild(tbl);
    }
    let end = (new Date()).getTime();
    let diff = end - start;
    console.log('Table created in ' + diff + ' ms');
}

function determineHint(cellContents) {
    let ret = 'S';
    switch (cellContents) {
        case CELLWITHNOMINESAROUNDDESIGNATOR:
            ret = 'L';
            break;
        case MINEMARKER:
            ret = MINEMARKER;
            break;
    }
    return ret;
}

function setMineCountDisplay() {
    let el = document.getElementById('minesLeft');
    el.innerText = minesLeft;
    let ratio = minesLeft / MINECOUNT;

    if (ratio <= 0.25) {
        el.classList = ['almostWon'];
    } else if (ratio <= 0.5) {
        el.classList = ['continuingToWin'];
    } else if (ratio <= 0.75) {
        el.classList = ['startingToWin'];
    } else {
        el.className = '';
    }
}

function clickCell(el) {
    el.target.classList.remove('hinted');
    let hidden = el.currentTarget.getAttribute('data-hidden');
    if (hidden == '0') {
        return;
    }
    revealCell(el.currentTarget);
}

function revealCell(el) {
    let row = el.getAttribute('data-row');
    let col = el.getAttribute('data-col');
    if (!map.get(row + '-' + col)) {
        map.set(row + '-' + col, 1);
    }
    let data = getCellData(row, col);
    el.innerText = data !== CELLWITHNOMINESAROUNDDESIGNATOR ? data : '';
    el.className = 'playingField';
    el.classList.add('revealed');
    el.setAttribute('data-hidden', 0);
    el.setAttribute('data-hint', SUPPOSEDMINEMARKER);

    if (data === MINEMARKER) {
        gameOver(false);
    } else if (data === CELLWITHNOMINESAROUNDDESIGNATOR) {
        el.removeEventListener('contextmenu', toggleDanger, false);
        let surroundingUnrevealedCells = getSurroundingHiddenCells(row, col);
        processCells(surroundingUnrevealedCells);
    } else if (map.size === FIELDHEIGHT * FIELDWIDTH - MINECOUNT && won === false) {
        won = true;
        gameOver(true);
    } else {
        el.addEventListener('dblclick', revealSurroundingCells, el);
        el.removeEventListener('contextmenu', toggleDanger, false);
    }
}

function revealSurroundingCells(el) {
    let row = el.target.getAttribute('data-row');
    let col = el.target.getAttribute('data-col');
    let toProcess = getSurroundingCellsThatCanBeRevealedBecauseAllDangerCellsAreMarked(row, col);
    if (toProcess.length) {
        processCells(toProcess);
    }
}

function getCellData(row, col) {
    return field[row][col];
}

function getSurroundingCells(rowStr, colStr) {
    let interimResult = [];
    let row = Number(rowStr);
    let col = Number(colStr);
    let firstRow = row === 0;
    let firstCol = col === 0;
    let lastRow = row === (field.length - 1);
    let lastCol = col === (field[row].length - 1);
    let midRow = !firstRow && (row < field.length - 1);
    let midCol = !firstCol && (col < field[row].length - 1);

    if (midRow && midCol) {
        interimResult.push(new Cell(row - 1, col)); //N
        interimResult.push(new Cell(row - 1, col + 1)); //NE
        interimResult.push(new Cell(row, col + 1)); //E
        interimResult.push(new Cell(row + 1, col + 1)); //SE
        interimResult.push(new Cell(row + 1, col)); //S
        interimResult.push(new Cell(row + 1, col - 1)); //SW
        interimResult.push(new Cell(row, col - 1)); //W
        interimResult.push(new Cell(row - 1, col - 1)); //NW
    } else if (midRow && firstCol) {
        interimResult.push(new Cell(row - 1, col)); //N
        interimResult.push(new Cell(row - 1, col + 1)); //NE
        interimResult.push(new Cell(row, col + 1)); //E
        interimResult.push(new Cell(row + 1, col + 1)); //SE
        interimResult.push(new Cell(row + 1, col)); //S
    } else if (midRow && lastCol) {
        interimResult.push(new Cell(row - 1, col)); //N
        interimResult.push(new Cell(row - 1, col - 1)); //NW
        interimResult.push(new Cell(row, col - 1)); //W
        interimResult.push(new Cell(row + 1, col - 1)); //SW
        interimResult.push(new Cell(row + 1, col)); //S
    } else if (firstRow && midCol) {
        interimResult.push(new Cell(row, col + 1)); //E
        interimResult.push(new Cell(row + 1, col + 1)); //SE
        interimResult.push(new Cell(row + 1, col)); //S
        interimResult.push(new Cell(row + 1, col - 1)); //SW
        interimResult.push(new Cell(row, col - 1)); //W
    } else if (lastRow && midCol) {
        interimResult.push(new Cell(row - 1, col)); //N
        interimResult.push(new Cell(row - 1, col + 1)); //NE
        interimResult.push(new Cell(row, col + 1)); //E
        interimResult.push(new Cell(row, col - 1)); //W
        interimResult.push(new Cell(row - 1, col - 1)); //NW
    } else if (firstRow && firstCol) { //top left
        interimResult.push(new Cell(row, col + 1)); //E
        interimResult.push(new Cell(row + 1, col + 1)); //SE
        interimResult.push(new Cell(row + 1, col)); //S
    } else if (firstRow && lastCol) { //top right
        interimResult.push(new Cell(row + 1, col)); //S
        interimResult.push(new Cell(row + 1, col - 1)); //SW
        interimResult.push(new Cell(row, col - 1)); //W
    } else if (lastRow && firstCol) { //bottom left
        interimResult.push(new Cell(row - 1, col)); //N
        interimResult.push(new Cell(row - 1, col + 1)); //NE
        interimResult.push(new Cell(row, col + 1)); //E
    } else if (lastRow && lastCol) { //bottom right
        interimResult.push(new Cell(row - 1, col)); //N
        interimResult.push(new Cell(row, col - 1)); //W
        interimResult.push(new Cell(row - 1, col - 1)); //NW
    } else {
        alert('should not be here, row: ' + row + ', col: ' + col);
    }
    return interimResult;
}

function getSurroundingHiddenCells(rowStr, colStr) {
    let interimResult = getSurroundingCells(rowStr, colStr);

    let result = [];

    interimResult.forEach(x => {
        let cell = getCell(x);
        if (cell) {
            let isHidden = this.isHidden(cell);
            let isDanger = cell.classList.contains('danger');
            if (isHidden && !isDanger)
                result.push(x);
        } else console.log('Cell not found with coordinates: ', x.row, x.col);
    });
    return result;
}

function getCell(x) {
    return document.querySelector('[data-cell="cell-' + x.row + '-' + x.col + '"]');
}

function getSurroundingCellsThatCanBeRevealedBecauseAllDangerCellsAreMarked(rowStr, colStr) {
    let interimResult = getSurroundingCells(rowStr, colStr);

    let result = [];
    let numberOfSurroundingCellsShouldBeMarkedAsDanger = parseInt(getCellData(rowStr, colStr));
    let numberMarked = 0;
    interimResult.forEach(x => {
        let cell = getCell(x);
        let isHidden = this.isHidden(cell);
        let isDanger = cell.classList.contains('danger');
        if (isDanger) numberMarked++;
        if (!isDanger && isHidden) result.push(x);
    });
    if (numberMarked === numberOfSurroundingCellsShouldBeMarkedAsDanger) return result;
    return [];
}

function processCells(cells) {
    while (cells.length > 0) {
        let first = cells.shift();
        let data = getCellData(first.row, first.col);
        let cell = getCell(first);
        revealCell(cell);
        if (data === '.') {
            processCells(getSurroundingHiddenCells(first.row, first.col));
        }
    }
    reassessWhetherCanGiveBigHint();
}

function isHidden(el) {
    let data = el.getAttribute('data-hidden');
    if (!data) return false;
    return data === '1';
}

function setRevealed(el) {
    el.setAttribute('data-hidden', 0);
}

function gameOver(win) {
    clearInterval(timerIntervalId);
    timerIntervalId = null;
    document.querySelectorAll('#playingField td').forEach(el => {
        let row = el.getAttribute('data-row');
        let col = el.getAttribute('data-col');

        let data = getCellData(row, col);
        el.classList.remove('hinted');
        el.removeEventListener('click', clickCell);
        el.removeEventListener('contextmenu', toggleDanger, false);
        if (data === MINEMARKER) {
            el.style.backgroundColor = (win ? 'green' : 'red');
            el.style.color = (win ? 'black' : 'white');
            el.innerHTML = REALMINEMARKERHTMLWHENREVEALED;
        } else if (data !== MINEMARKER && el.classList.contains('danger')) {
            el.classList.remove('danger');
            el.classList.add('wrong');
            el.innerHTML = WRONGMINEMARKER;
            minesLeft += 1;
        }
    });

    let li = document.createElement('li');
    li.classList.add(win ? 'win' : 'loss');
    li.innerHTML = formatSecondsIntoTimeString(getElapsedSecondsAdjustedForPenalties()); //< 5 seconds, do something that doesn't count
    if (!win) {
        li.innerHTML += ', ' + (MINECOUNT - minesLeft) + ' out of ' + MINECOUNT + ' correct';
    }
    else {
        minesLeft = 0;
        setMineCountDisplay();

        if (hintCount > 0) {
            let formattedPenaltyTime = formatSecondsIntoTimeString(penaltyTimeInSeconds);
            li.innerHTML += `. ${hintCount} hint${hintCount > 1 ? 's' : ''}  used for a total penalty time of ${formattedPenaltyTime}.`;
        } else {
            li.innerHTML += `. No hints used! ${randomCompliment()}!`;
        }
    }
    document.getElementById('scoreboardDiv').classList.remove('is-hidden');
    document.getElementById('results').appendChild(li);
    document.getElementById('smallHintButton').disabled = true;
    document.getElementById('largeHintButton').disabled = true;
}

function giveHint(isBig) {
    let hintCandidates = getHintCandidates(isBig);
    let hintCandidatesCount = hintCandidates.length;

    if (hintCandidatesCount > 0) {
        let rnd = randomNumber(hintCandidates.length);
        hintCandidates[rnd].classList.add('hinted');
    }
    penaltyTimeInSeconds += (isBig ? 30 : 10);
    hintCount++;
}

function reassessWhetherCanGiveBigHint() {
    let largeHintCandidatesNumber = getHintCandidates(true).length;
    document.getElementById('largeHintButton').disabled = largeHintCandidatesNumber === 0;
}

function getHintCandidates(isBigHint) {
    return document.querySelectorAll("#playingField td[data-hint='" + (isBigHint ? "L" : "S") + "']");
}

function toggleDanger(el) {
    el.preventDefault();
    if (el.target.classList.contains('danger')) {
        minesLeft += 1;
        el.target.addEventListener('click', clickCell);
        el.target.classList.remove('danger');
        el.target.innerText = '?';
    } else {
        minesLeft -= 1;
        el.target.removeEventListener('click', clickCell);
        el.target.classList.add('danger');
        el.target.innerText = SUPPOSEDMINEMARKER;
    }
    setMineCountDisplay();
    return false;
}

function calcFieldMarker(row, col) {
    let n = calcN(row, col);
    let ne = calcNE(row, col);
    let e = calcE(row, col);
    let se = calcSE(row, col);
    let s = calcS(row, col);
    let sw = calcSW(row, col);
    let w = calcW(row, col);
    let nw = calcNW(row, col);
    return n + ne + e + se + s + sw + w + nw;
}

function calcN(row, col) {
    if (row === 0) return 0;
    return field[row - 1][col] === MINEMARKER ? 1 : 0;
}

function calcNE(row, col) {
    if (row === 0 || col === field[row].length) return 0;
    return field[row - 1][col + 1] === MINEMARKER ? 1 : 0;
}

function calcE(row, col) {
    if (col === field[row].length) return 0;
    return field[row][col + 1] === MINEMARKER ? 1 : 0;
}

function calcSE(row, col) {
    if (row === field.length - 1 || col === field[row].length) return 0;
    return field[row + 1][col + 1] === MINEMARKER ? 1 : 0;
}

function calcS(row, col) {
    if (row === field.length - 1) return 0;
    return field[row + 1][col] === MINEMARKER ? 1 : 0;
}

function calcSW(row, col) {
    if (row === field.length - 1 || col === 0) return 0;
    return field[row + 1][col - 1] === MINEMARKER ? 1 : 0;
}

function calcW(row, col) {
    if (col === 0) return 0;
    return field[row][col - 1] === MINEMARKER ? 1 : 0;
}

function calcNW(row, col) {
    if (row === 0 || col === 0) return 0;
    return field[row - 1][col - 1] === MINEMARKER ? 1 : 0;
}

function randomNumber(upperBound) {
    return Math.floor(Math.random() * upperBound);
}

function randomCompliment() {
    const compliments = ['Way to go', 'Impressive', 'Quite a feat', 'Great job', 'Amazing', 'Nice', 'Wonderful', 'Great', 'Incredible', 'Excellent', 'Perfect'];
    return compliments[randomNumber(compliments.length)];
}

function resetGameParametersAndStartNewGame() {
    resetGameParameters();
    resetGame();
}

function smallestAndEasiest() {
    setGameParameters([5, 5, 5]);
    resetGame();
}

function largestAndHardest() {
    debugger;
    setGameParameters([20, 20, 100]);
    resetGame();
}