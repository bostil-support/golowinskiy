window.onload = function () {

    let now = new Date();
    document.getElementById('doc_clock').textContent = now.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit', hour12: false });
    document.getElementById('doc_day').textContent = now.toLocaleDateString('ru', { weekday: 'long', month: 'long', day: 'numeric' });

    setTimeout(() => {
        document.getElementById('doc_clock').style.opacity = 0;
        document.getElementById('doc_day').style.opacity = 0;
    }, 3000);
};
