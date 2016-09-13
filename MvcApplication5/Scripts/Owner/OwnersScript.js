$(".btn-success").on('click', function (e) {
    switch (e.target.name) {
        case "Details":
            var id = e.target.getAttribute('data-id');
            document.location.href = 'http://' + document.location.host + '/Home/DetailsOwner/' + id;
            break;
        case "Edit":
            var id = e.target.getAttribute('data-id');
            document.location.href = 'http://' + document.location.host + '/Home/EditOwner/' + id;
            break;

       

    }

});


$("#addbutton").on('click', function () {
    document.location.href = 'http://' + document.location.host + '/Owner/CreateOwner';
});



function AjaxSuccess(data) {
    $('#tablebody').empty();
    for (var i = 0; i < data.length; i++) {
        $('#tablebody').append('<tr><td>' + data[i].Surname_Owner + '</td><td>' + data[i].Name_Owner + '</td><td>' +
            data[i].Birsday_owner.ToShortDateString() + '</td>' +
            '<td>' + data[i].Driving_experience + '</td>' +
          +'<td><button class="btn-success" value="Details" data-id="data[i].Id_owner" name="Details">Details</button></td>' +
'<td><button class="btn-success" value="Edit" data-id="data[i].Id_owner" name="Edit">Edit</button></td>' +
'td><button class="btn-success" value="Delete" data-id="data[i].Id_owner" name="Delete">Delete</button></td></tr>')

    }
}


