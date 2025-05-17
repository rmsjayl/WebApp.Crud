// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.
var METHODS = {
    GET: 'GET',
    POST: 'POST',
    DELETE: 'DELETE',
    PUT: 'POST'
};


function openModal() {
    $("#studentModal").modal("show");
}


function getStudent(studentId) {
    fetch(`/api/Student/${studentId}`, {
        method: METHODS.GET,
    })
        .then(response => response.json())
        .then(student => {
            console.log("Data: ", student);
        })
        .catch(error => console.log("Error fetching student:", error));
}

function editModal(studentId) {
    fetch(`/api/Student/${studentId}`
    )
        .then(response => response.json())
        .then(student => {
            document.getElementById("modalBody").innerHTML = `
            <p><strong>First Name:</strong> ${student.firstName}</p>
            <p><strong>Last Name:</strong> ${student.lastName}</p>
            <p><strong>University:</strong> ${student.university}</p>
            <p><strong>Cell Phone:</strong> ${student.cellPhoneNumber}</p>
            <button onclick="deleteStudent('${student.id}')" class="btn btn-danger">Edit</button>
        `;

            let modal = new bootstrap.Modal(document.getElementById("studentModal"));
            modal.show();
        })
        .catch(error => console.log("Error fetching student:", error));
}
