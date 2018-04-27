var result = {
    init: function () {
        result.registerEvents();
    },
    registerEvents: function () {
        $(document).ready(function () { changeClass(); changeClassmodel(); });
    }
}
result.init();

function changeClass() {
    // Get a list of classes and a list of lecturers of the first lectuers.
    $.getJSON('/AddData/GetListUsers', null, function (data) {
        $.each(data, function () {
            $('#lecturer').append('<option value=' +
              this.ID + '>' + this.Name + '</option>');
        });
        $.getJSON('/Students/GetListClass', { userid: $('#lecturer').val() }, function (data) {
            $.each(data, function () {
                $('#class').append('<option value=' +
                  this.IDClass + '>' + this.NameClass + '</option>');
            });
        }).fail(function (jqXHR, textStatus, errorThrown) {
            alert('Error getting this class!');
        });
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alert('Error getting this lecturer!' + errorThrown);
    });

    // Dropdown list change event.
    $('#lecturer').change(function () {
        $('#class option').remove();
        $.getJSON('/Students/GetListClass', { userid: $('#lecturer').val() }, function (data) {
            $.each(data, function () {
                $('#class').append('<option value=' +
                    this.IDClass + '>' + this.NameClass + '</option>');
            });
        }).fail(function (jqXHR, textStatus, errorThrown) {
            alert('Error getting class change event!');
        });
    });
};
function changeClassmodel() {
    // Get a list of classes and a list of lecturers of the first lectuers.
    $.getJSON('/Students/GetListUsers', null, function (data) {
        $.each(data, function () {
            $('#IDLecturer').append('<option value=' +
              this.ID + '>' + this.Name + '</option>');
        });
        $.getJSON('/Students/GetListClass', { userid: $('#IDLecturer').val() }, function (data) {
            $.each(data, function () {
                $('#IDClass').append('<option value=' +
                  this.IDClass + '>' + this.NameClass + '</option>');
            });
        }).fail(function (jqXHR, textStatus, errorThrown) {
            alert('Error getting this class!');
        });
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alert('Error getting this lecturer!' + errorThrown);
    });

    // Dropdown list change event.
    $('#IDLecturer').change(function () {
        $('#IDClass option').remove();
        $.getJSON('/Students/GetListClass', { userid: $('#IDLecturer').val() }, function (data) {
            $.each(data, function () {
                $('#IDClass').append('<option value=' +
                    this.IDClass + '>' + this.NameClass + '</option>');
            });
        }).fail(function (jqXHR, textStatus, errorThrown) {
            alert('Error getting class change event!');
        });
    });
};