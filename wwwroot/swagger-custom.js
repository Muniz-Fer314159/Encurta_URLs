const interval = setInterval(() => {
    const filter = document.querySelector(".filter");
    if (filter) {
        filter.placeholder = "Buscar endpoints da API...";
        filter.style.borderRadius = "10px";
        filter.style.padding = "10px";
        clearInterval(interval);
    }
}, 100);

const titleInterval = setInterval(() => {
    const topbar = document.querySelector(".topbar");
    if (topbar) {
        const badge = document.createElement("div");
        badge.innerHTML =
            "<span style='color:#60a5fa;font-weight:bold;font-size:14px;margin-left:10px;'>• Ambiente de Desenvolvimento</span>";
        topbar.appendChild(badge);
        clearInterval(titleInterval);
    }
}, 100);
