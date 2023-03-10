// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const flashcards = document.querySelectorAll('.flashcard');

flashcards.forEach(function(flashcard) {
    flashcard.addEventListener('click', function () {
        flashcard.classList.toggle('flipped');
    });
});