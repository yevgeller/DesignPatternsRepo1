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
let COUNTDOWNSECONDS = 60;
resetGameParameters();
const MINEMARKER = 'O';
const WRONGMINEMARKER = '<i class="fa-solid fa-ban"></i>';
const CELLWITHNOMINESAROUNDDESIGNATOR = '.';
const SUPPOSEDMINEMARKER = 'X';
const EXPLODEDONTHISMINE = 'E';
const REALMINEMARKERHTMLWHENREVEALED = '<i class="fa-solid fa-asterisk"></i>';
const REVEALEDCORRECTMINEMARKER = '<i class="fa-solid fa-check"></i>';
const EXPLODEDMINEMARKER = '<i class="fa-solid fa-explosion"></i>';
const TIMEDMODEICON = '<i class="fa-solid fa-stopwatch ml-1"></i>';
let field = Array.from(Array(FIELDHEIGHT), () => new Array(FIELDWIDTH).fill(CELLWITHNOMINESAROUNDDESIGNATOR));
let map = new Map();
let won = false;
let minesLeft = 0;
let timerIntervalId, timedModeTimerIntervalId;
let hintCount = 0;
let penaltyTimeInSeconds = 0;
let secondsInAMinute = 60;
let secondsInAnHour = secondsInAMinute * 60;
let secondsInADay = secondsInAnHour * 24;
let timedMode = false;
let countdownSeconds = COUNTDOWNSECONDS;
let countUpSeconds = 0;
let gameInProgress = false;
let resumeGameButton, pauseGameButton;
let showInstructions = false;
let results = [];
let currentResultId = 0;

class Cell {
    constructor(row, col) {
        this.row = row;
        this.col = col;
    }
}

function getCurrentResultId() {
    return currentResultId++;
}

function addTestResults() {
    console.log('adding test results');
    results.push(new Result(true, 10, 10, 20, 20, 90, 0, false, 0));
    results.push(new Result(false, 10, 10, 3, 20, 10, 1, false, 10));
    results.push(new Result(false, 10, 10, 0, 19, 5, 0, false, 0));
    results.push(new Result(true, 9, 9, 20, 20, 90, 0, false, 0));
    results.push(new Result(false, 9, 9, 3, 20, 10, 0, false, 0));
    results.push(new Result(false, 9, 9, 0, 19, 5, 0, false, 0));
    results.push(new Result(true, 11, 11, 20, 20, 90, 0, false, 0));
    results.push(new Result(false, 11, 11, 3, 20, 10, 0, false, 0));
    results.push(new Result(false, 11, 11, 0, 19, 5, 2, false, 20));
    results.push(new Result(true, 10, 10, 20, 20, 55, 0, true, 0));
    results.push(new Result(false, 10, 10, 3, 20, 15, 0, true, 0));
    results.push(new Result(false, 10, 10, 0, 19, 8, 0, true, 0));
    results.push(new Result(true, 9, 9, 20, 20, 100, 3, true, 50));
    results.push(new Result(false, 9, 9, 3, 20, 20, 0, true, 0));
    results.push(new Result(false, 9, 9, 0, 19, 25, 0, true, 0));
    showResults();
}

class Result {
    constructor(win, width, height, mines, minesTotal, duration, hints, isTimedMode, penalty = 0) {
        this.timeStamp = new Date().getTime();
        this.win = win;
        this.width = width;
        this.height = height;
        this.mines = mines;
        this.minesTotal = minesTotal;
        this.duration = duration;
        this.hints = hints;
        this.isTimedMode = isTimedMode;
        this.penalty = penalty;
    }

    get result() {
        let li = document.createElement('li');
        li.classList.add(this.win ? 'win' : 'loss');
        li.innerHTML = formatSecondsIntoTimeString(this.duration + this.penalty);
        if (this.penalty > 0) li.innerHTML += ` (${formatSecondsIntoTimeString(this.penalty)} penalty)`;
        if (!this.win) {
            li.innerHTML += `, ${this.mines} out of ${this.minesTotal} correct`;
        }
        else {
            setMineCountDisplay();

            if (hintCount > 0) {
                let formattedPenaltyTime = formatSecondsIntoTimeString(this.penalty);
                li.innerHTML += `. ${this.hints} hint${this.hints > 1 ? 's' : ''}  used for a total penalty time of ${formattedPenaltyTime}.`;
            } else {
                li.innerHTML += `. No hints used! ${randomCompliment()}!`;
            }
        }
        if (this.isTimedMode) li.innerHTML += TIMEDMODEICON;
        return li;
    }

    get comparator() {
        if (this.duration < 10) return Number.MIN_SAFE_INTEGER;
        return this.width * this.height * this.minesTotal * (this.duration + this.penalty);
    }

    get header() {
        if (!this.win && this.duration < 10) {
            return `Unlucky start/quick loss:`;
        }
        return `${this.width} x ${this.height}, ${this.minesTotal} mines:`
    }

    get headerComparator() {
        if (this.duration < 10) return Number.MIN_SAFE_INTEGER;
        return this.width * this.height * this.minesTotal;
    }

    get headerObject() {
        return { 'header': this.header, 'headerComparator': this.headerComparator, 'height': this.height, 'width': this.width };
    }

    get summary() {
        return `${this.width}x${this.height} (${this.win ? 'won' : 'lost'}${this.win ? '' : ', '}${this.win ? '' : (this.mines + '/' + this.minesTotal)}), ${this.duration}+${this.penalty}`
    }
}

function compareResultsHeader(result) {

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
    setMinMaxParameters('minesAmountInput', MINMINESCOUNT, (FIELDHEIGHT * FIELDWIDTH - 1));
}

function determineUserInputAsInt(min, max, fieldName, defaultValue) {
    let userInput = document.getElementById(fieldName).value;
    let candidate = parseInt(userInput);
    if (!candidate) return defaultValue;
    if (candidate < min) return min;
    if (candidate > max) return max;

    return candidate;
}

function setInputParameter(id, val) {
    document.getElementById(id).value = val;
}

function setMinMaxParameters(id, min, max) {
    document.getElementById(id).min = min;
    document.getElementById(id).max = max;
}

document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('timedModeSwitch').addEventListener('click', toggleTimedMode, false);
    pauseGameButton = document.getElementById('pauseGameButton');
    resumeGameButton = document.getElementById('resumeGameButton');
    resetGame();
    //https://stackoverflow.com/questions/16006583/capturing-ctrlz-key-combination-in-javascript
    document.addEventListener('keydown', function (event) {
        if (event.key === 'n') {
            resetGame();
        }
        if (event.key === 'p') {
            if (pauseGameButton.classList.contains('is-hidden')) {
                resumeGame();
            } else {
                pauseGame();
            }
        }
    });
});

function stopAndClearAllGameTimers() {
    clearInterval(timerIntervalId);
    timerIntervalId = null;
    clearInterval(timedModeTimerIntervalId);
    timedModeTimerIntervalId = null;
}

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
    createFakeTable();
    minesLeft = MINECOUNT;
    setMineCountDisplay();

    hintCount = 0;
    stopAndClearAllGameTimers();
    document.getElementById('timerValue').classList = [];
    timedMode = document.getElementById('chbTimedMode').checked;
    console.log('timedMode:', timedMode);
    if (timedMode) {
        countdownSeconds = COUNTDOWNSECONDS;
        document.getElementById('timerHeaderString').innerText = 'Remaining time';
        document.getElementById('timerValue').innerText = `${countdownSeconds} seconds`;
        document.getElementById('timerValue').classList.add('is-size-2');
        freeBigHint();
    } else {
        countUpSeconds = 0;
        document.getElementById('timerHeaderString').innerText = 'Elapsed time';
        document.getElementById('timerValue').innerText = `Timer will start as soon as any cell on the field is clicked.`;
        document.getElementById('timerValue').classList.add('is-size-6');
    }
    document.querySelectorAll('#playingField td').forEach(el => el.addEventListener('click', clickCell));
    document.querySelectorAll('#playingField td').forEach(el => el.addEventListener('contextmenu', toggleDanger, false));
    document.getElementById('largeHintButton').disabled = !getHintCandidates(true).length;
    document.getElementById('smallHintButton').disabled = false;
    document.getElementById('minesLeft').className = '';
    resumeGameUIchanges();
    pauseGameButton.disabled = true;
    let end = (new Date()).getTime();
    let diff = end - start;
    console.log('Game is set and ready in ' + diff + ' ms');
}

function processCountUpTimer() {
    countUpSeconds++;
    showElapsedTimer();
}

function showElapsedTimer() {
    let seconds = countUpSeconds + penaltyTimeInSeconds;
    document.getElementById('timerValue').innerText = formatSecondsIntoTimeString(seconds);
}

function processCountdownInTimedMode() {
    countdownSeconds -= 1;
    if (countdownSeconds <= 0) {
        countdownSeconds = 0;
        gameOver(false);
    }
    showTimedModeCountdown();
}

function showTimedModeCountdown() {
    let el = document.getElementById('timerValue');
    el.innerText = formatSecondsIntoTimeString(countdownSeconds);
    el.classList = [];
    el.classList.add(...determineSizeOfTimerText(countdownSeconds));
}

function determineSizeOfTimerText(secondsLeft) {
    let ratio = secondsLeft / COUNTDOWNSECONDS;
    if (ratio >= 0.7) return ['is-size-2'];
    if (ratio > 0.5) return ['is-size-2', 'colorYellow'];
    if (ratio > 0.25) return ['is-size-2', 'colorOrange'];
    return ['is-size-2', 'colorRed'];
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

    while (mineCount > 0) {
        let rndRow = randomNumber(FIELDHEIGHT);
        let rndCol = randomNumber(FIELDWIDTH);
        if (field[rndRow][rndCol] !== MINEMARKER) {
            field[rndRow][rndCol] = MINEMARKER;
            mineCount--;
        }
    }
}

function calculateMarkers() {
    for (let i = 0; i < field.length; i++) {
        for (let j = 0; j < field[i].length; j++) {
            if (field[i][j] === MINEMARKER) continue;
            let marker = calcFieldMarker(i, j);
            if (marker > 0) {
                field[i][j] = marker.toString();
            }
        }
    }
}

function createTable() {
    let container = document.getElementById('tbl');
    container.innerHTML = '';
    let tbl = document.createElement('table');
    tbl.setAttribute('id', 'playingField');
    let tbody = document.createElement('tbody')
    for (let i = 0; i < FIELDHEIGHT; i++) {
        let tr = document.createElement('tr');
        for (let j = 0; j < FIELDWIDTH; j++) {
            let td = document.createElement('td');
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
}

function createFakeTable() {
    let filler = 'P A U S E D '.split('');
    let container = document.getElementById('tbl_paused');
    container.innerHTML = '';
    let tbl = document.createElement('table');
    tbl.setAttribute('id', 'fakePlayingField');
    let tbody = document.createElement('tbody')
    for (let i = 0; i < FIELDHEIGHT; i++) {
        let tr = document.createElement('tr');
        for (let j = 0; j < FIELDWIDTH; j++) {
            let td = document.createElement('td');
            td.classList.add('playingField');
            let charHere = filler[(j + i) % filler.length];
            td.appendChild(document.createTextNode(charHere));
            tr.appendChild(td);
            tbody.appendChild(tr);
        }
        tbl.appendChild(tbody);
        container.appendChild(tbl);
    }
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
    document.getElementById('minesLeft').innerText = minesLeft >= 0 ? minesLeft : '?';

    let el = document.getElementById('remainingMineCounterArea');
    document.getElementById('minesPluralOrSingular').innerHTML = minesLeft === 1 ? '' : 's';
    let ratio = minesLeft / MINECOUNT;
    //remainingMineCounterArea
    if (ratio < 0) {
        el.classList = ['negativeMineCount'];
    } else if (ratio <= 0.25) {
        el.classList = ['almostWon'];
    } else if (ratio <= 0.5) {
        el.classList = ['continuingToWin'];
    } else if (ratio <= 0.75) {
        el.classList = ['startingToWin'];
    } else {
        el.className = 'initialMineCount';
    }
}

function clickCell(el) {
    gameInProgress = true;
    pauseGameButton.disabled = false;
    if (timedMode && !timedModeTimerIntervalId) {
        startCountdownTimer();
    }
    if (!timedMode && !timerIntervalId) {
        startCountUpTimer();
    }
    el.target.classList.remove('hinted');
    let hidden = el.currentTarget.getAttribute('data-hidden');
    if (hidden == '0') {
        return;
    }
    revealCell(el.currentTarget);
}

function determineRowAndCol(attrData) {
    //attrData is expected to be 'cell-X-Y' where X is row and Y is column
    let ret = attrData.replace('cell-', '').split('-');
    if (ret.length !== 2) {
        console.error(`Cannot extract row/col from ${attrData}`);
        throw 'Improper format for data-cell attribute';
    }

    return ret;
}

function revealCell(el) {
    let rowCol = determineRowAndCol(el.getAttribute('data-cell'));
    let row = rowCol[0];
    let col = rowCol[1];

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
        field[row][col] = EXPLODEDONTHISMINE;
        el.innerHTML = EXPLODEDMINEMARKER;
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
    let rowCol = determineRowAndCol(el.target.getAttribute('data-cell'));
    let row = rowCol[0];
    let col = rowCol[1];
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
    stopAndClearAllGameTimers();
    document.querySelectorAll('#playingField td').forEach(el => {
        let rowCol = determineRowAndCol(el.getAttribute('data-cell'));
        let row = rowCol[0];
        let col = rowCol[1];

        let data = getCellData(row, col);
        el.classList.remove('hinted');
        el.removeEventListener('click', clickCell);
        el.removeEventListener('contextmenu', toggleDanger, false);
        if (data === MINEMARKER || data === EXPLODEDONTHISMINE) {
            el.style.backgroundColor = (win ? 'green' : 'red');
            el.style.color = (win ? 'black' : 'white');
            if (data === MINEMARKER) el.innerHTML = el.classList.contains('danger') ? REVEALEDCORRECTMINEMARKER : REALMINEMARKERHTMLWHENREVEALED;
            if (data === EXPLODEDONTHISMINE) el.innerHTML = EXPLODEDMINEMARKER;
        } else if (data !== MINEMARKER && el.classList.contains('danger')) {
            el.classList.remove('danger');
            el.classList.add('wrong');
            el.innerHTML = WRONGMINEMARKER;
            minesLeft += 1;
        }
    });

    results.push(new Result(win, FIELDWIDTH, FIELDHEIGHT, MINECOUNT - minesLeft, MINECOUNT, timedMode ? (COUNTDOWNSECONDS - countdownSeconds) : countUpSeconds, hintCount, timedMode, penaltyTimeInSeconds));
    showResults();

    document.getElementById('scoreboardDiv').classList.remove('is-hidden');
    document.getElementById('smallHintButton').disabled = true;
    document.getElementById('largeHintButton').disabled = true;
    pauseGameButton.disabled = true;
}

function showResults() {
    document.getElementById('scoreboardDiv').classList.remove('is-hidden');
    let headers = [];
    results.forEach(x => {
        let candidate = headers.filter(h =>
            (h.header == x.headerObject.header && h.headerComparator == Number.MIN_SAFE_INTEGER)
            ||
            (h.header == x.headerObject.header
                && h.headerComparator == x.headerObject.headerComparator
                && h.height == x.headerObject.height
                && h.width == x.headerObject.width)
            //need to handle quick losses
        );
        if (!candidate.length)
            headers.push(x.headerObject);
    });
    //Have current category always on top
    headers.sort((a, b) => a.headerComparator - b.headerComparator);
    let lastResultTimeStamp = Math.max(...results.map(o => o.timeStamp));
    let lastPlayedCategoryCandidate = results.filter(x => x.timeStamp == lastResultTimeStamp);
    debugger;

    //let distinctHeaders = Array.from(new Set(headers)).sort();
    let rootEl = document.getElementById('results');
    rootEl.innerHTML = "";

    //test this:
    if (lastPlayedCategoryCandidate.length === 1) {
        createResultContainer(lastPlayedCategoryCandidate[0], rootEl, lastResultTimeStamp);
    }

    //remove duplicate element here:
    headers.filter(x=>x.timeStamp != lastResultTimeStamp).forEach(hdr => {
        //test this
        createResultContainer(hdr, rootEl, lastResultTimeStamp);
    });
}

function createResultContainer(header, rootEl, lastResultTimeStamp) {
    let resultContainer = document.createElement('div');
    let headerElement = document.createElement('h3');
    headerElement.innerText = header.header;
    headerElement.classList.add('is-size-3');
    resultContainer.appendChild(headerElement);

    determineResultsToDisplay(true, header.header, resultContainer, lastResultTimeStamp);
    determineResultsToDisplay(false, header.header, resultContainer, lastResultTimeStamp);

    rootEl.appendChild(resultContainer);
}

function determineResultsToDisplay(gameStatus, hdr, resultContainer, lastResultTimeStamp) {
    let filteredResults = results
        .filter(x => x.header === hdr && x.win === gameStatus)
        .sort((a, b) => a.comparator - b.comparator);
    if (!hdr.toLowerCase().startsWith('un')) {
        createResultCategoryHeader(resultContainer, filteredResults.length, gameStatus);
    }
    createAndDisplayListOfResults(filteredResults, gameStatus, resultContainer, lastResultTimeStamp);
}

function createResultCategoryHeader(container, resultsCount, gameStatus) {
    let header = document.createElement('h1');
    header.classList.add('is-size-5');

    if (resultsCount === 0) {
        header.innerHTML = gameStatus ? "No wins" : "No losses";
    } else {
        header.innerHTML = gameStatus ? "Wins" : "Losses";
    }
    container.appendChild(header);
}

function createAndDisplayListOfResults(results, gameStatus, container, lastResultTimeStamp) {

    if (results.length > 0) {

        let listContainer = document.createElement('ol');
        results.forEach(res => {
            let result = res.result;
            if (res.timeStamp === lastResultTimeStamp) result.classList.add('latestResult');
            listContainer.appendChild(result);
        });

        container.appendChild(listContainer);
    }
}

function giveHint(isBig) {
    let hintCandidates = getHintCandidates(isBig);
    let hintCandidatesCount = hintCandidates.length;

    if (hintCandidatesCount > 0) {
        let rnd = randomNumber(hintCandidates.length);
        hintCandidates[rnd].classList.add('hinted');
    }
    penaltyTimeInSeconds += (isBig ? 30 : 10);
    if (timedMode) countdownSeconds -= (isBig ? 30 : 10);
    hintCount++;
}

function freeBigHint() {
    let hintCandidates = getHintCandidates(true);
    let hintCandidatesCount = hintCandidates.length;

    if (hintCandidatesCount > 0) {
        let rnd = randomNumber(hintCandidates.length);
        hintCandidates[rnd].classList.add('hinted');
    }
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
    setGameParameters([20, 20, 100]);
    resetGame();
}

function setGameParamsToCustom() {
    console.log('currently checked', document.getElementById('chbCustom').checked);
    document.getElementById('chbCustom').checked = true;
}

function toggleTimedMode(e) {
    //debugger;
    //try this:
    timedMode = !timedMode
    document.getElementById('chbTimedMode').checked = timedMode;
    resetGame();
    e.preventDefault();

    //document.getElementById('chbTimedMode').checked = !document.getElementById('chbTimedMode').checked;
    //resetGame();
    //e.preventDefault();
}

function pauseGame() {
    document.getElementById('tbl').classList.add('is-hidden');
    document.getElementById('tbl_paused').classList.remove('is-hidden');
    resumeGameButton.classList.remove('is-hidden');
    pauseGameButton.classList.add('is-hidden');
    stopAndClearAllGameTimers();
}

function resumeGame() {
    resumeGameUIchanges();
    resumeGameHandleTimers();
}

function resumeGameUIchanges() {
    document.getElementById('tbl').classList.remove('is-hidden');
    document.getElementById('tbl_paused').classList.add('is-hidden');
    resumeGameButton.classList.add('is-hidden');
    pauseGameButton.classList.remove('is-hidden');
}

function resumeGameHandleTimers() {
    timedMode ? startCountdownTimer() : startCountUpTimer();
}

function startCountUpTimer() {
    if (!timerIntervalId) {
        timerIntervalId = setInterval(processCountUpTimer, 1000);
    }
}

function startCountdownTimer() {
    if (!timedModeTimerIntervalId) {
        timedModeTimerIntervalId = setInterval(processCountdownInTimedMode, 1000);
    }
}

function toggleInstructions() {
    showInstructions = !showInstructions;
    let el = document.getElementById('instructionsBody');
    if (showInstructions) el.classList.remove('is-hidden');
    if (!showInstructions) el.classList.add('is-hidden');
}