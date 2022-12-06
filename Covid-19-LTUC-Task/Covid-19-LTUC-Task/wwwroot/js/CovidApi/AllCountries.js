$(document).ready(function () {
    AllCountriesDetails();

})

function AllCountriesDetails() {
  $('#MyDiv').html("");
    appendElement = "";
    $.ajax({
        type: "GET",
        url: 'https://api.covid19api.com/summary',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result, status, xhr) {
            $.each(result.Countries, function (i) {
                appendElement += '<div class="card ">';
                appendElement += '<div class="card-body">'
                appendElement += '<h5 class="card-title" style="color:red"> Country : <span class="' + result.Countries[i].ID +'CountryName">' + result.Countries[i].Country + '</span></h5>'
                appendElement += '<p class="card-text" >Total Confirmed Cases<span class="' + result.Countries[i].ID +'Confirmed">' + result.Countries[i].TotalConfirmed + '</span></p>'
                appendElement += '<p class="card-text" >Total Deaths Cases <span class="' + result.Countries[i].ID +'Deaths">' + result.Countries[i].TotalDeaths + '</span></p>'
                appendElement += '<p class="card-text" >Total Recovered Cases <span class="' + result.Countries[i].ID +'Recovered">' + result.Countries[i].TotalRecovered + '</span></p>'
                appendElement += '<p class="card-text" > Date <span class="' + result.Countries[i].ID +'Date">' + result.Countries[i].Date + '</span></p>'
                appendElement += '<button type="button" class="AddRecord" id ="' + result.Countries[i].ID +'" onclicK="AddRecord()"> Add To My Records</button>'
                appendElement += '</div>';
                appendElement += '</div>';
                //alert(JSON.stringify(url));
                //alert(JSON.stringify(result[i]));
                //$('#Date').html(result.Date);
                //$('#Cases').html(result.Cases);
                //$('#TotalRecovered').html(result.TotalRecovered);
            })            
            $('#MyDiv').append(appendElement);
        }, error:
            function (jqXHR, textStatus, errorThrown) {
                if (jqXHR.status == 500) {
                    // alert(Internal error: + jqXHR.responseText);
                }
                else {
                    // alert(Unexpected error: + jqXHR.responseText);
                }
            }
    });
}

$(document).on("click", ".AddRecord",  function () {
    
        debugger;
        var Id = $(this).attr("id");    
    //var Data = {
    //    CountryName: $("." + Id + "CountryName").text(),
    //    TotalConfirmed: $("." + Id + 'Confirmed' ).text(),
    //    TotalDeaths: $("." + Id + "Deaths").text(),
    //    TotalCases: $("." + Id + "Recovered").text(),
    //    Date: $("." + Id + "Date").html(),
    //};

    $.ajax({

        url: "/Countries/Add" + Id,
        type: "Post",
        data: Data,
        contentType: "application/json",
        processData: false,
        contentType: false,
        success: function (result, status, xhr) {
            alert("updated");
        },
        error: function (jqXHR, textStatus, errorThrown) {

            if (jqXHR.status == 500) {
                alert("No");
                //alert(@@#Internal error: @@# + jqXHR.responseText);
            }
            else {
            }
        }
    });

    alert(JSON.stringify(Data));
});




