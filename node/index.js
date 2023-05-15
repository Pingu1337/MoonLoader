import readline from 'readline';

export default class MoonLoader {
  #Moons = ["🌕", "🌖", "🌗", "🌘", "🌑", "🌒", "🌓", "🌔"];
  #moonIndex = 0;
  #hideCursor;
  #delay;

  constructor(delay, hideCursor) {
    this.#delay = delay;
    this.#hideCursor = hideCursor;
    hideCursor && process.stdout.write('\x1B[?25l');
  }

  async Spin(args) {
    await new Promise((r) => setTimeout(r, this.#delay));
    this.#displayMoon();
  }

  Done() {
    this.#hideCursor && process.stdout.write('\x1B[?25h');
    console.log(" ");
  }

  #displayMoon() {
    _clearLine();
    process.stdout.write(this.#getCurrentMoon());
  }

  #getCurrentMoon() {
    const output = this.#Moons[this.#moonIndex];
    this.#moonIndex = (this.#moonIndex + 1) % this.#Moons.length;
    return output;
  }
}

function _clearLine() {
  readline.clearLine(process.stdout, 0);
  readline.cursorTo(process.stdout, 0);
}
