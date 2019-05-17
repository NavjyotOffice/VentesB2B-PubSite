var trackEnum = { click: "click", open: "open", pixel: "pixel" };

function colectFormData() {
    return {
        Email: $("#Email").val(),
        FirstName: $("#FirstName").val(),
        LastName: $("#LastName").val(),
        Company: $("#Company").val(),
        Address: $("#Address").val(),
        City: $("#City").val(),
        State: $("#State").val(),
        Zip: $("#Zip").val(),
        Country: $("#Country").val(),
        Phone: $("#Phone").val(),
        JobTitle: $("#JobTitle").val(),
        Revenue: $("#Revenue").val(),
        EmployeeSize: $("#EmployeeSize").val(),
        Industry: $("#Industry").val(),
        CustomQuestion1: $("#CustomQuestion1").val(),
        CustomQuestion2: $("#CustomQuestion2").val(),
        CustomQuestion3: $("#CustomQuestion3").val(),
        CustomQuestion4: $("#CustomQuestion4").val(),
        CustomQuestion5: $("#CustomQuestion5").val(),
        OptIn: $("#OptIn").is(":checked"),
        CampaignName: $("#CampaignName").val()
    };
}

function PostDataFormSubmit(data, thankYouURL, track) {
    data.Track = track.toLowerCase();
    $.ajax({
        type: 'Post',
        url: '../api/LandingPageTrack',
        data: JSON.stringify(data),
        success: function (data) {
            if (thankYouURL != null && thankYouURL != "") {
                window.location = thankYouURL;
            }
        },
        contentType: "application/json",
        dataType: 'json'
    });
}

function getUrlVars() {
    var vars = {}, hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        //vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}

function hideQueryStringFields() {

    var queryStringValues = getUrlVars();

    if (queryStringValues != null) {
        if (queryStringValues.FirstName) {
            $("#FirstName").val(queryStringValues.FirstName);
            $("#FirstName").hide();
        }
        if (queryStringValues.LastName) {
            $("#LastName").val(queryStringValues.LastName);
            $("#LastName").hide();
        }
        if (queryStringValues.Company) {
            $("#Company").val(queryStringValues.Company);
            $("#Company").hide();
        }
        if (queryStringValues.Address) {
            $("#Address").val(queryStringValues.Address);
            $("#Address").hide();
        }
        if (queryStringValues.City) {
            $("#City").val(queryStringValues.City);
            $("#City").hide();
        }
        if (queryStringValues.State) {
            $("#State").val(queryStringValues.State);
            $("#State").hide();
        }
        if (queryStringValues.Zip) {
            $("#Zip").val(queryStringValues.Zip);
            $("#Zip").hide();
        }
        if (queryStringValues.Country) {
            $("#Country").val(queryStringValues.Country);
            $("#Country").hide();
        }
        if (queryStringValues.Phone) {
            $("#Phone").val(queryStringValues.Phone);
            $("#Phone").hide();
        }
        if (queryStringValues.JobTitle) {
            $("#JobTitle").val(queryStringValues.JobTitle);
            $("#JobTitle").hide();
        }
        if (queryStringValues.Revenue) {
            $("#Revenue").val(queryStringValues.Revenue);
            $("#Revenue").hide();
        }
        if (queryStringValues.EmployeeSize) {
            $("#EmployeeSize").val(queryStringValues.EmployeeSize);
            $("#EmployeeSize").hide();
        }
        if (queryStringValues.Industry) {
            $("#Industry").val(queryStringValues.Industry);
            $("#Industry").hide();
        }
        if (queryStringValues.CustomQuestion1) {
            $("#CustomQuestion1").val(queryStringValues.CustomQuestion1);
            $("#CustomQuestion1").hide();
        }
        if (queryStringValues.CustomQuestion2) {
            $("#CustomQuestion2").val(queryStringValues.CustomQuestion2);
            $("#CustomQuestion2").hide();
        }
        if (queryStringValues.CustomQuestion3) {
            $("#CustomQuestion3").val(queryStringValues.CustomQuestion3);
            $("#CustomQuestion3").hide();
        }
        if (queryStringValues.CustomQuestion4) {
            $("#CustomQuestion4").val(queryStringValues.CustomQuestion4);
            $("#CustomQuestion4").hide();
        }
        if (queryStringValues.CustomQuestion5) {
            $("#CustomQuestion5").val(queryStringValues.CustomQuestion5);
            $("#CustomQuestion5").hide();
        }
        if (queryStringValues.Email) {
            $("#Email").val(queryStringValues.Email);
            $("#Email").hide();
            if (queryStringValues.Track) {
                PostDataFormSubmit(colectFormData(), "", trackEnum.pixel);
            }
            else {
                PostDataFormSubmit(colectFormData(), "", trackEnum.open);
            }
        }
    }
}