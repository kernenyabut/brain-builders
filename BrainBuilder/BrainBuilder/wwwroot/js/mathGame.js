
//Variable declaration
let firstNumber = 0;
let secondNumber = 0;
let answerNumber = 0;
let randomOperator;
let roundsPlayed = 0;
let roundsWon = 0;
let gamePlayed = false;
let gameGoing = false;
let userAnswer = 0;
let timer;


//initial game start
function StartGame() {
    gameReset();
    gameGoing = true;
    document.getElementById('gameStartBtn').style.visibility = 'hidden';
    document.getElementById('gameSubmitBtn').style.visibility = 'hidden';
    NewRound();
    CountDownTimer();
}


//Start a new round
function NewRound() {
    firstNumber = Math.floor(Math.random() * 101);
    secondNumber = Math.floor(Math.random() * 101);
    randomOperator = Math.floor(Math.random() * 2) + 1;

    document.getElementById('gameNumberOne').value = firstNumber;
    document.getElementById('gameNumberTwo').value = secondNumber;

    if (randomOperator == 1) {
        answerNumber = firstNumber + secondNumber;
        document.getElementById('gameOperator').value = "+";
    }
    else if (randomOperator == 2) {
        answerNumber = firstNumber - secondNumber;
        document.getElementById('gameOperator').value = "-";
    }

    gamePlayed = true;
}


//Check if the user's answer is correct
function CheckAnswer() {
    if (gamePlayed && gameGoing) {
        userAnswer = document.getElementById('userAnswer').value;
        if (answerNumber == userAnswer) {
            document.getElementById('gameNotifications').innerHTML = userAnswer + " was correct!"

            roundsPlayed++;
            roundsWon++;
        }
        else {
            document.getElementById('gameNotifications').innerHTML = "Sorry " + userAnswer + " wasn't right."

            roundsPlayed++;
        }
        document.getElementById('gameRounds').value = roundsWon + " out of " + roundsPlayed;
        document.getElementById('userAnswer').value = "";
    }
    else if (gamePlayed && !gameGoing) {
        document.getElementById('gameNotifications').innerHTML = " Start a new game to continue."
    }
    else {
        alert("Please play a round before submitting an answer.")
    }
}


//Reset round tracters
function gameReset() {
    roundsWon = 0;
    roundsPlayed = 0;
    document.getElementById('gameNumberOne').value = "";
    document.getElementById('gameOperator').value = "";
    document.getElementById('gameNumberTwo').value = "";
    document.getElementById('gameRounds').value = "";
}


//Submit scores to DB (WIP)
function SubmitScore() {
    alert("Submitting score");
}


//Count down from seconds
function CountDownTimer() {
    timer = setInterval(countDown, 1000);
    let seconds = 60;

    function countDown() {
        document.getElementById("gameTime").value = --seconds;
        if (seconds == 0) {
            clearInterval(timer);
            document.getElementById("gameTime").value = "Time is up!";
            document.getElementById('gameStartBtn').style.visibility = 'visible';
            document.getElementById('gameSubmitBtn').style.visibility = 'visible';
            document.getElementById('gameNotifications').innerHTML = "Start a new game to continue."

            gameGoing = false;
        }
    }
}


//Event listener for hitting enter on the answer field
document.getElementById("userAnswer").addEventListener("keydown", function (e) {
    var keyCode = e.keyCode || e.which;
    //Enter pressed
    if (keyCode === 13) {
        //Check answer and start new round
        CheckAnswer();
        NewRound();
    }
}, false);