document.addEventListener("DOMContentLoaded", () => {
    const form = document.getElementById("shorten-form");
    const input = document.getElementById("originalUrl");
    const resultDiv = document.getElementById("result");

    form.addEventListener("submit", async (e) => {
        e.preventDefault();
        resultDiv.textContent = "";
        const originalUrl = input.value.trim();
        if (!originalUrl) return;

        try {
            const response = await fetch("/shorten", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({ OriginalUrl: originalUrl })
            });
            if (!response.ok) {
                const errText = await response.text();
                resultDiv.textContent = "Erro: " + errText;
                return;
            }
            const data = await response.json();
            let shortUrl;
            if (data.shortUrl) {
                shortUrl = data.shortUrl;
            } else if (data.key) {
                shortUrl = window.location.origin + "/" + data.key;
            } else {
                resultDiv.textContent = "Resposta inesperada da API";
                return;
            }

            resultDiv.innerHTML = `
                <p>URL encurtada: <a href="${shortUrl}" target="_blank">${shortUrl}</a></p>
            `;
        } catch (err) {
            console.error(err);
            resultDiv.textContent = "Erro ao conectar à API.";
        }
    });
});
