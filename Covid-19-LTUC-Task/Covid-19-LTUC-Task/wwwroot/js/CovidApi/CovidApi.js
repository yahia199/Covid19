

$(document).ready(function () {
    
    WorldTotal();
})
function WorldTotal() {
    $.ajax({
        type: "GET",
        url: "https://api.covid19api.com/world/total",
        
        contentType: "application/json; charset=utf-8",
        dataType: "json",    
        success: function (result, status, xhr) {
            alert(JSON.stringify(result));
            $('#TotalConfirmed').html(result.TotalConfirmed);
            $('#TotalDeaths').html(result.TotalDeaths);
            $('#TotalRecovered').html(result.TotalRecovered);

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

$(document).on("click", "#btnSearch", function () {
    statisticsforaspecificcountry();
});

function statisticsforaspecificcountry() {
    var country = $('#Country').val();
    var FromDate = $('#FromDate').val();
    var ToDate = $('#ToDate').val();
    var Myurl = "https://api.covid19api.com/country/" + country + "/status/confirmed?from=" + FromDate + "T00:00:00Z&to=" + ToDate + "T00:00:00Z";
    $('#MyDiv').html("");
    appendElement = "";
    $.ajax({
        type: "GET",
        url: Myurl,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result, status, xhr) {
            $.each(result, function (i) {

                appendElement += '<div class="card">';
                appendElement += '<div class="card-body">'
                appendElement += '<h5 class="card-title" style="color:red"> Date' + result[i].Date + '</h5>'
                appendElement += '<p class="card-text"> Cases' + result[i].Cases + '</p>'
                appendElement += '</div>';
                appendElement += '</div>';
            })

            $('.MyDiv').append(appendElement);
        }, error:
            function (error) {
                
            }
    });
}

