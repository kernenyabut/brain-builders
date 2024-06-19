/* Created using tutorial from Code Sketch
 * https://www.youtube.com/watch?v=eMhiMsEC9Uk&list=PLLX1I3KXZ-YH-woTgiCfONMya39-Ty8qw 
 * Created By: James Parks 2021*/

const cards = document.querySelectorAll('.memoryCard');

/* Declaring Variables */
let hasFlippedCard = false;
let lockBoard = true;
let firstCard, secondCard;
let userMoves;
let userScore;
let playTime;
let startTime;
let currentTime;
let matchNumber;

/* Function for Card Flipping */
function flipCard() {
    if (lockBoard) return;
    if (this === firstCard) return;

    this.classList.add('flip');

    if (!hasFlippedCard) {
        hasFlippedCard = true;
        firstCard = this;

        return;
    }

    secondCard = this;

    checkForMatch();
}

/* Function to check if two cards are a match */
function checkForMatch() {
    if (firstCard.dataset.framework === secondCard.dataset.framework) {
        matchNumber = matchNumber + 1;

        if (matchNumber == 6) {
            victoryScore();
        }

        calculateScore();

        disableCards();
    }
    else {
        userMoves = userMoves + 1;
        updateScore();
        unflipCards();
    }
}

/* Function to reset the card variables if two cards are not a match */
function resetBoard() {
    hasFlippedCard = false;
    lockBoard = false;
    [firstCard, secondCard] = [null, null];
}

/* Function to disable cards if two match */
function disableCards() {
    firstCard.removeEventListener('click', flipCard);
    secondCard.removeEventListener('click', flipCard);

    resetBoard();
}

/* Function to unflip cards if they do not match */
function unflipCards() {
    lockBoard = true;

    setTimeout(() => {
        firstCard.classList.remove('flip');
        secondCard.classList.remove('flip');

        resetBoard();
    }, 1500);
}

/* Function to shuffle the game board */
(function shuffle() {
    cards.forEach(card => {
        let randomPos = Math.floor(Math.random() * 12);
        card.style.order = randomPos;
    });
    resetScore();
})();

/* Function to start the game */
function startGame() {
    lockBoard = false;
    startTime = new Date();
    matchNumber = 0;
    resetScore();
}

/* Function to calculate the current play time */
function calculateTime() {
    currentTime = new Date();
    playTime = (currentTime - startTime) / 1000;
    playTime = Math.round(playTime);
}

/* Function to reset the score when the player starts */
function resetScore() {
    userMoves = 0;
    userScore = 0;
    playTime = 0;
    updateScore();
}

/* Function to update the score counters */
function updateScore() {
    calculateTime();
    document.getElementById('gameMoves').value = userMoves;
    document.getElementById('gameScore').value = userScore;
    document.getElementById('gameTime').value = playTime;
}

/* Function to calculate how many points a player gets after a match */
function calculateScore() {
    userMoves = userMoves + 1;

    if (userMoves < 9) {
        userScore = userScore + 10;
    }
    else if (userMoves > 8 && userMoves < 13) {
        userScore = userScore + 7;
    }
    else if (userMoves > 12 && userMoves < 16) {
        userScore = userScore + 4;
    }
    else {
        userScore = userScore + 1;
    }

    updateScore();
}

/* Function to give player additional points if they complete the game fast enough */
function victoryScore() {
    if (playTime < 61) {
        userScore = userScore + 40;
    }
    else if (playTime > 60 && playTime < 121) {
        userScore = userScore + 20;
    }

    //Allows submit button to be enabled
    document.getElementById("btnSubmit").disabled = false;
}

/* Adding an event listener to each card to activate flip on click */
cards.forEach(card => card.addEventListener('click', flipCard));