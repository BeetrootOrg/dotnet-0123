const BOARD_SIZE = 10;
const MINE_COUNT = 10;

const board = document.getElementById('board');
const cells = [];
let mineLocations = [];

function createBoard() {
    for (let i = 0; i < BOARD_SIZE; i++) {
        cells[i] = [];
        for (let j = 0; j < BOARD_SIZE; j++) {
            const cell = document.createElement('div');
            cell.classList.add('cell');
            cell.dataset.row = i;
            cell.dataset.col = j;
            cell.addEventListener('click', handleCellClick);
            board.appendChild(cell);
            cells[i][j] = cell;
        }
    }
}

function placeMines() {
    mineLocations = [];
    while (mineLocations.length < MINE_COUNT) {
        const row = Math.floor(Math.random() * BOARD_SIZE);
        const col = Math.floor(Math.random() * BOARD_SIZE);
        if (!mineLocations.some(loc => loc.row === row && loc.col === col)) {
            mineLocations.push({ row, col });
            cells[row][col].classList.add('mine');
        }
    }
}

function handleCellClick(event) {
    const cell = event.target;
    const row = parseInt(cell.dataset.row);
    const col = parseInt(cell.dataset.col);

    if (cell.classList.contains('mine')) {
        revealMines();
        alert('Кабум! Ви програли!');
        resetGame();
    } else {
        const mineCount = getMineCount(row, col);
        cell.textContent = mineCount || '';
        cell.classList.add('revealed');
        cell.removeEventListener('click', handleCellClick);

        if (mineCount === 0) {
            revealEmptyCells(row, col);
        }

        if (checkWin()) {
            revealMines();
            alert('Ура! Перемога!');
            resetGame();
        }
    }
}

function getMineCount(row, col) {
    let count = 0;
    for (let i = Math.max(row - 1, 0); i <= Math.min(row + 1, BOARD_SIZE - 1); i++) {
        for (let j = Math.max(col - 1, 0); j <= Math.min(col + 1, BOARD_SIZE - 1); j++) {
            if (i === row && j === col) continue;
            if (cells[i][j].classList.contains('mine')) count++;
        }
    }
    return count;
}

function revealEmptyCells(row, col) {
    for (let i = Math.max(row - 1, 0); i <= Math.min(row + 1, BOARD_SIZE - 1); i++) {
        for (let j = Math.max(col - 1, 0); j <= Math.min(col + 1, BOARD_SIZE - 1); j++) {
            if (i === row && j === col) continue;
            const cell = cells[i][j];
            if (!cell.classList.contains('revealed')) {
                const mineCount = getMineCount(i, j);
                cell.textContent = mineCount || '';
                cell.classList.add('revealed');
                cell.removeEventListener('click', handleCellClick);
                if (mineCount === 0) {
                    revealEmptyCells(i, j);
                }
            }
        }
    }
}

function revealMines() {
    mineLocations.forEach(loc => {
        const { row, col } = loc;
        cells[row][col].classList.add('revealed');
    });
}

function checkWin() {
    for (let i = 0; i < BOARD_SIZE; i++) {
        for (let j = 0; j < BOARD_SIZE; j++) {
            const cell = cells[i][j];
            if (!cell.classList.contains('revealed') && !cell.classList.contains('mine')) {
                return false;
            }
        }
    }
    return true;
}

function resetGame() {
    board.innerHTML = '';
    cells.length = 0;
    mineLocations.length = 0;
    createBoard();
    placeMines();
}

createBoard();
placeMines();


