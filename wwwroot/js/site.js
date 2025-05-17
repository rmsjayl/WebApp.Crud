
var METHODS = {
    GET: 'GET',
    POST: 'POST',
    DELETE: 'DELETE',
    PUT: 'PUT'
}

function createStudent() {
    document.getElementById("modalBody").innerHTML = `
        <form id="studentForm">
            <label for="firstName">First Name:</label>
            <input type="text" id="firstName" name="firstName" class="form-control" required>

            <label for="lastName">Last Name:</label>
            <input type="text" id="lastName" name="lastName" class="form-control" required>

            <label for="university">University:</label>
            <input type="text" id="university" name="university" class="form-control" required>

             <label for="address">Address:</label>
            <input type="text" id="address" name="address" class="form-control" required>

            <label for="cellPhoneNumber">Cell Phone Number:</label>
            <input type="text" id="cellPhoneNumber" name="cellPhoneNumber" class="form-control" required>

            <button type="submit" class="btn btn-success mt-3">Create</button>
        </form>
    `;
    $("#studentModal").modal("show");
    $("#studentForm").submit(function (event) {
        event.preventDefault();

        var studentData = {
            firstName: $("#firstName").val(),
            lastName: $("#lastName").val(),
            university: $("#university").val(),
            address: $("#address").val(),
            cellPhoneNumber: $("#cellPhoneNumber").val()
        };

        $.ajax({
            type: METHODS.POST,
            contentType: "application/json",
            url: "api/Student",
            data: JSON.stringify(studentData),
            success: function () {
                alert("Student created successfully!");
                $("#studentModal").modal("hide");
                window.location.reload();
            },
            error: function (error) {
                alert(`Error creating student: ${error}`);
            }
        });
    });
}

function getStudent(studentId) {
    $.ajax({
        type: METHODS.GET,
        url: `api/Student/${studentId}`,
        contentType: 'application/json',
        success: function (student) {
            document.getElementById("modalBody").innerHTML = `
                <p><strong>First Name:</strong> ${student.firstName}</p>
                <p><strong>Last Name:</strong> ${student.lastName}</p>
                <p><strong>University:</strong> ${student.university}</p>
                <p><strong>Cell Phone:</strong> ${student.cellPhoneNumber}</p>
            `;
            // Show modal
            $("#studentModal").modal("show");
        },
        error: function (error) {
            alert(`Fetching of student has encountered an error: ${error}`);
            window.location.reload();
        }
    });
}

function deleteStudent(studentId) {
    $.ajax({
        type: METHODS.DELETE,
        contentType: 'application/json',
        url: `api/Student/${studentId}`,
        success: function (student) {
            alert(`Student with an ID of ${studentId} has been successfully deleted.`);
            window.location.reload();
        },
        error: function (error) {
            alert(`Deletion of student has encountered an error: ${error}`);
            window.location.reload();
        }
    })
}

function editModal(studentId) {
    // Fetch student details before showing modal
    $.ajax({
        type: METHODS.GET,
        contentType: "application/json",
        url: `api/Student/${studentId}`,
        success: function (student) {
            // Populate modal with student details
            document.getElementById("modalBody").innerHTML = `
                <form id="studentForm">
                    <label for="firstName">First Name:</label>
                    <input type="text" id="firstName" name="firstName" class="form-control" value="${student.firstName}" required>

                    <label for="lastName">Last Name:</label>
                    <input type="text" id="lastName" name="lastName" class="form-control" value="${student.lastName}" required>

                    <label for="university">University:</label>
                    <input type="text" id="university" name="university" class="form-control" value="${student.university}" required>

                    <label for="address">Address:</label>
                    <input type="text" id="address" name="address" class="form-control" value="${student.address}" required>

                    <label for="cellPhoneNumber">Cell Phone Number:</label>
                    <input type="text" id="cellPhoneNumber" name="cellPhoneNumber" class="form-control" value="${student.cellPhoneNumber}" required>

                    <button type="submit" class="btn btn-warning mt-3">Update</button>
                </form>
            `;

            $("#studentModal").modal("show");
            $("#studentForm").submit(function (event) {
                event.preventDefault();

                var updatedStudentData = {
                    firstName: $("#firstName").val(),
                    lastName: $("#lastName").val(),
                    university: $("#university").val(),
                    address: $("#address").val(),
                    cellPhoneNumber: $("#cellPhoneNumber").val()
                };

                $.ajax({
                    type: METHODS.PUT,
                    contentType: "application/json",
                    url: `api/Student/${studentId}`,
                    data: JSON.stringify(updatedStudentData),
                    success: function () {
                        alert("Student updated successfully!");
                        $("#studentModal").modal("hide");
                        window.location.reload();
                    },
                    error: function (error) {
                        alert(`Error updating student: ${error}`);
                    }
                });
            });
        },
        error: function (error) {
            alert(`Error fetching student details: ${error}`);
        }
    });
}

