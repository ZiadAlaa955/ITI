//Interface
interface ICardData {
  cardImage: string;
}

//Classes
class Card implements ICardData {
  cardNumber: number;
  cardImage: string;
  isFlipped: boolean;
  isMatched: boolean;
  htmlElement: HTMLElement | null;

  constructor(data: ICardData, slotNumber: number) {
    this.cardNumber = slotNumber; // Set the ID based on the slot it was dealt
    this.cardImage = data.cardImage;
    this.isFlipped = false;
    this.isMatched = false;

    this.htmlElement = document.getElementById("card-" + this.cardNumber);

    if (this.htmlElement) {
      let frontImage = this.htmlElement.querySelector(
        ".card-front",
      ) as HTMLImageElement;
      frontImage.src = this.cardImage;
    }
  }

  flip() {
    if (!this.isFlipped && !this.isMatched) {
      this.isFlipped = true;
      this.htmlElement?.classList.add("flipped");
    }
  }
  unflip() {
    if (this.isFlipped) {
      this.isFlipped = false;
      this.htmlElement?.classList.remove("flipped");
    }
  }
  lock() {
    this.isMatched = true;
  }
}

class ProgressBar {
  percentage: number;
  fillElement: HTMLElement | null;
  textElement: HTMLElement | null;

  constructor() {
    this.percentage = 0;
    this.fillElement = document.getElementById("progress-fill");
    this.textElement = document.getElementById("progress-text");
  }

  updateProgressbar(totalMatchedpairs: number, totalCards: number) {
    this.percentage = ((totalMatchedpairs * 2) / totalCards) * 100;

    if (this.fillElement) {
      this.fillElement.style.width = `${this.percentage}%`;
    }
    if (this.textElement) {
      this.textElement.innerText = `${Math.round(this.percentage)}%`;
    }
  }
}

class SoundManager {
  backgroundSound: HTMLAudioElement;
  flipSound: HTMLAudioElement;
  matchSound: HTMLAudioElement;
  mismatchSound: HTMLAudioElement;
  gameoverSound: HTMLAudioElement;

  constructor() {
    this.backgroundSound = new Audio("assets/audio/fulltrack.mp3");
    this.flipSound = new Audio("assets/audio/flip.mp3");
    this.gameoverSound = new Audio("assets/audio/game-over.mp3");
    this.matchSound = new Audio("assets/audio/good.mp3");
    this.mismatchSound = new Audio("assets/audio/fail.mp3");
  }

  playBackgroundSound() {
    this.backgroundSound.currentTime = 0;
    this.backgroundSound.play();
  }
  playFlipSound() {
    this.flipSound.currentTime = 0;
    this.flipSound.play();
  }
  playMatchSound() {
    this.matchSound.currentTime = 0;
    this.matchSound.play();
  }
  playMismatchSound() {
    this.mismatchSound.currentTime = 0;
    this.mismatchSound.play();
  }
  playGameoverSound() {
    this.gameoverSound.currentTime = 0;
    this.gameoverSound.play();
  }
  stopBackgroundSound() {
    this.backgroundSound.currentTime = 0;
    this.backgroundSound.pause();
  }
}

class Game {
  cards: Card[];
  totalMatchedPairs: number;
  firstFlippedCard: Card | null;
  secondFlippedCard: Card | null;
  isProcessing: boolean;
  soundManager: SoundManager;
  progressBar: ProgressBar;

  constructor(cardsArray: ICardData[]) {
    let shuffledData = this.shuffle(cardsArray);
    this.cards = shuffledData.map((data, index) => new Card(data, index + 1));

    this.totalMatchedPairs = 0;
    this.firstFlippedCard = null;
    this.secondFlippedCard = null;
    this.isProcessing = false;
    this.soundManager = new SoundManager();
    this.progressBar = new ProgressBar();

    this.cards.forEach((card) => {
      card.htmlElement?.addEventListener("click", () => {
        this.cardClick(card);
      });
    });
  }

  startGame() {
    this.soundManager.playBackgroundSound();
  }

  shuffle(cardsArray: ICardData[]) {
    let currentIndex = cardsArray.length;
    let randomIndex;

    while (currentIndex != 0) {
      randomIndex = Math.floor(Math.random() * currentIndex);
      currentIndex--;

      let temp = cardsArray[currentIndex]!;
      cardsArray[currentIndex] = cardsArray[randomIndex]!;
      cardsArray[randomIndex] = temp;
    }
    return cardsArray;
  }

  cardClick(clickedCard: Card) {
    if (this.isProcessing || clickedCard.isFlipped) return;

    this.soundManager.playFlipSound();
    clickedCard.flip();

    if (this.firstFlippedCard == null) this.firstFlippedCard = clickedCard;
    else {
      this.secondFlippedCard = clickedCard;
      this.checkForMatch(this.firstFlippedCard, this.secondFlippedCard);
    }
  }

  checkForMatch(firstFlippedCard: Card, secondFlippedCard: Card) {
    if (firstFlippedCard.cardImage == secondFlippedCard.cardImage) {
      this.soundManager.playMatchSound();

      firstFlippedCard.lock();
      secondFlippedCard.lock();

      this.totalMatchedPairs++;
      this.progressBar.updateProgressbar(this.totalMatchedPairs, 20);
      this.resetTurn();

      if (this.totalMatchedPairs === 10) {
        this.endGame();
      }
    } else {
      this.soundManager.playMismatchSound();
      this.isProcessing = true;
      setTimeout(() => {
        firstFlippedCard.unflip();
        secondFlippedCard.unflip();
        this.resetTurn();
      }, 1000);
    }
  }

  resetTurn() {
    this.firstFlippedCard = null;
    this.secondFlippedCard = null;
    this.isProcessing = false;
  }

  endGame() {
    this.soundManager.stopBackgroundSound();
    this.soundManager.playGameoverSound();
  }
}

//Cards Data Array
let cardsData: ICardData[] = [
  { cardImage: "assets/images/angularjs.png" },
  { cardImage: "assets/images/angularjs.png" },
  { cardImage: "assets/images/css.png" },
  { cardImage: "assets/images/css.png" },
  { cardImage: "assets/images/docker.png" },
  { cardImage: "assets/images/docker.png" },
  { cardImage: "assets/images/html.png" },
  { cardImage: "assets/images/html.png" },
  { cardImage: "assets/images/javascript.png" },
  { cardImage: "assets/images/javascript.png" },
  { cardImage: "assets/images/mongodb.png" },
  { cardImage: "assets/images/mongodb.png" },
  { cardImage: "assets/images/nodejs.png" },
  { cardImage: "assets/images/nodejs.png" },
  { cardImage: "assets/images/react.png" },
  { cardImage: "assets/images/react.png" },
  { cardImage: "assets/images/typescript.png" },
  { cardImage: "assets/images/typescript.png" },
  { cardImage: "assets/images/vue-js.png" },
  { cardImage: "assets/images/vue-js.png" },
];

//Main
let myGame = new Game(cardsData);
myGame.startGame();
