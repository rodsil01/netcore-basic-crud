document.addEventListener('DOMContentLoaded', () => {
    getTableData();
});

const getTableData = () => {
    fetch('http://localhost:5221/api/positions', {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
        }
      })
        .then(response => {
            try {
                return response.json();
            } catch (error) {
                throw new Error();
            }
        })
        .then(data => {
            buildTable(data);
        })
        .catch(error => {
            alert("Ocurrió un error al obtener los registros")
            console.error('Error:', error);
        });
}

const buildTable = (positions) => {
    const positionsTable = document.getElementById("positions-table-data");

    while (positionsTable.firstChild) {
        positionsTable.removeChild(positionsTable.firstChild);
    }

    positions.forEach(p => {
        const tableRow = document.createElement("tr");
        const codeCell = document.createElement("td");
        const descriptionCell = document.createElement("td");
        const actionsCell = document.createElement("td");
    
        codeCell.innerText = p?.genId || "";
        descriptionCell.innerText = p?.description || "";

        actionsCell.innerHTML = `
            <div class="action-buttons">
                <div>
                    <button type="button" id="positions-edit-btn-${p?.id || ""}">Editar</button>
                </div>
                <div>
                    <button type="button" id="positions-delete-btn-${p?.id || ""}">Eliminar</button>
                </div>
            </div>
        `;

        tableRow.appendChild(codeCell.cloneNode(true));
        tableRow.appendChild(descriptionCell.cloneNode(true));
        tableRow.appendChild(actionsCell.cloneNode(true));

        positionsTable.appendChild(tableRow.cloneNode(true))

        const editPositionButton = document.getElementById(`positions-edit-btn-${p?.id || ""}`);
        const deletePositionButton = document.getElementById(`positions-delete-btn-${p?.id || ""}`);

        editPositionButton.addEventListener("click", () => editPositionClicked(p?.id || ""));
        deletePositionButton.addEventListener("click", () => deletePositionClicked(p?.id || ""));
    });
}

const editPositionClicked = (id) => {
    window.location.href = `./positions-edit.html?id=${id}`
}

const deletePositionClicked = (id) => {
    fetch(`http://localhost:5221/api/positions/${id}`, {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json',
        }
      })
        .then(response => {
            getTableData();
            console.log('Response:', response);
        })
        .catch(error => {
            alert("Ocurrió un error al obtener los registros")
            console.error('Error:', error);
        });
}
