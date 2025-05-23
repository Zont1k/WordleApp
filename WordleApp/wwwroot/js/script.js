document.addEventListener('DOMContentLoaded', () => {
    // Виртуальная клавиатура
    const keyboardKeys = document.querySelectorAll('.keyboard-key');
    const guessInput = document.querySelector('.guess-input');

    keyboardKeys.forEach(key => {
        key.addEventListener('click', () => {
            const action = key.getAttribute('data-action');
            const keyValue = key.getAttribute('data-key');

            if (action === 'backspace') {
                guessInput.value = guessInput.value.slice(0, -1);
            } else if (action === 'submit') {
                if (guessInput.value.length === 5) {
                    document.querySelector('.guess-form').submit();
                } else {
                    guessInput.classList.add('shake');
                    setTimeout(() => {
                        guessInput.classList.remove('shake');
                    }, 500);
                }
            } else if (keyValue && guessInput.value.length < 5) {
                guessInput.value += keyValue.toLowerCase();
            }
        });
    });

    // Анимации плиток
    const animateTiles = () => {
        const tiles = document.querySelectorAll('.game-tile[data-animation]');

        tiles.forEach(tile => {
            const delay = tile.getAttribute('data-delay') * 100;
            const animation = tile.getAttribute('data-animation');

            setTimeout(() => {
                tile.style.animation = `${animation} 0.5s ease`;

                if (tile.classList.contains('tile-correct')) {
                    setTimeout(() => {
                        tile.style.animation = 'dance 0.5s ease';
                    }, 500);
                }
            }, delay);
        });
    };

    animateTiles();

    // Ограничение ввода только букв
    guessInput.addEventListener('input', (e) => {
        e.target.value = e.target.value.replace(/[^а-яА-Я]/g, '').toUpperCase();
    });

    // Фокус на поле ввода при загрузке
    guessInput.focus();

    // Обработка нажатий клавиш
    document.addEventListener('keydown', (e) => {
        if (e.key === 'Enter' && guessInput.value.length === 5) {
            document.querySelector('.guess-form').submit();
        } else if (e.key === 'Backspace') {
            guessInput.value = guessInput.value.slice(0, -1);
        } else if (/^[а-яА-Я]$/.test(e.key) && guessInput.value.length < 5) {
            guessInput.value += e.key.toUpperCase();
        } else if (guessInput.value.length < 5) {
            guessInput.classList.add('shake');
            setTimeout(() => {
                guessInput.classList.remove('shake');
            }, 500);
        }
    });
});