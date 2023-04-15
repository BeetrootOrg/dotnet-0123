let fontSize = parseInt(window.getComputedStyle(document.querySelector('html')).fontSize);

document.querySelector('#zoom-in').addEventListener('click', function() {
    zoomFont('in');
});

document.querySelector('#zoom-out').addEventListener('click', function() {
    zoomFont('out');
});

function zoomFont(direction) {
    const minSize = 10;
    const step = 2;

    if (direction == 'out' && fontSize == minSize) {
        return;
    }

    fontSize += direction == 'in' ? step : -step;
    document.querySelector('html').style.fontSize = `${fontSize}px`;
} 

document.querySelectorAll('.btn-hiding').forEach(function(currentBtn) {
    currentBtn.addEventListener('click', displayingContent);
});

function displayingContent(e) {
    const content = e.target.parentElement.nextElementSibling;
    content.classList.toggle('hidden');
    e.target.textContent = content.classList.contains('hidden') ? 'Show' : 'Hide';
}
