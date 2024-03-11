let positionId = null;
const savePositionButton = document.getElementById("positions-save-btn");

document.addEventListener('DOMContentLoaded', () => {
  const searchParams = new URLSearchParams(window.location.search);
  
  const positionId = searchParams.get("id");

  if (positionId) {
    initEditionView(positionId);
  }
});

savePositionButton.addEventListener("click", () => {
    if (positionId == null) {
      createNewPosition();
    } else {
      editExistingPosition();
    }
});

const initEditionView = (id) => {
  fetch(`http://localhost:5221/api/positions/${id}`, {
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
      const positionCodeInput = document.getElementById("position-code");
      const positionDescriptionInput = document.getElementById("position-description");

      if (!positionCodeInput || !positionDescriptionInput) return;
      if (!data || !data.id || !data.genId || !data.description) return;

      positionCodeInput.value = data.genId;
      positionDescriptionInput.value = data.description;

      positionId = data.id;
    })
    .catch(error => {
        alert("Ocurrió un error al obtener los registros")
        console.error('Error:', error);
    });
}

const createNewPosition = () => {
  const descriptionInputValue = document.getElementById("position-description");

  if (!descriptionInputValue) return;

  fetch('http://localhost:5221/api/positions', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify({
      description: descriptionInputValue.value
    })
  })
    .then(response => {
      window.location.href = "./positions.html"
      console.log('Response:', response);
    })
    .catch(error => {
      alert("Ocurrió un error al crear el registro")
      console.error('Error:', error);
    });
}

const editExistingPosition = () => {
  const descriptionInputValue = document.getElementById("position-description");

  if (!descriptionInputValue || !positionId) return;

  fetch(`http://localhost:5221/api/positions/${positionId}`, {
    method: 'PATCH',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify({
      description: descriptionInputValue.value
    })
  })
    .then(response => {
      window.location.href = "./positions.html"
      console.log('Response:', response);
    })
    .catch(error => {
      alert("Ocurrió un error al obtener los registros")
      console.error('Error:', error);
    });
}
