const LAST_RESULT_KEY = "LAST-RESULT";

const results = []

const calculateButton = document.getElementById("calculate-btn");
const saveToDBButton = document.getElementById("save-to-db-btn");

calculateButton.addEventListener("click", () => {
    const inputValue = document.getElementById("input-value");
    const lastResult = document.getElementById("last-result");
    const resultsContainer = document.getElementById("results-container");

    var allowedCharacters = /^[0-9+\-*/(). ]+$/;

    if (!inputValue || !inputValue.value || !lastResult || !resultsContainer) return;

    if (!allowedCharacters.test(inputValue.value)) {
        alert("Syntax Error");
    }

    try {
        const result = eval(inputValue.value);

        results.push(result);

        lastResult.value = result;
        localStorage.setItem(LAST_RESULT_KEY, result);

        resultsContainer.style.display = "block";

        updateChildren()
    } catch (error) {
        alert("Syntax Error");
    }
});

saveToDBButton.addEventListener("click", () => {
    fetch('http://localhost:5221/api/calculator', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            values: results.map(r => parseFloat(r))
        })
      })
        .then(response => {
            console.log('Response:', response);
        })
        .catch(error => {
            console.error('Error:', error);
        });
});

document.addEventListener('DOMContentLoaded', () => {
    const lastResult = localStorage.getItem(LAST_RESULT_KEY);

    if (!lastResult) return;

    const resultsListContainer = document.getElementById("last-result-container");
    const lastResultInput = document.getElementById("last-result");

    if (!resultsListContainer || !lastResultInput) return;

    resultsListContainer.style.display = "flex";
    lastResultInput.value = lastResult;
});

const updateChildren = () => {
    const resultsList = document.getElementById("results-list");

    if (!resultsList) return;

    const resultChildren = results.map(r => {
        const listItem = document.createElement("li");
        listItem.innerText = r;
        return listItem;
    });

    while (resultsList.firstChild) {
        resultsList.removeChild(resultsList.firstChild);
    }

    resultChildren.forEach(c => resultsList.appendChild(c.cloneNode(true)));
}
