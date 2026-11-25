// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(() => {
    LoadProdData();
    var connection = new signalR.HubConnectionBuilder().withUrl("/signalrServer").build();
    connection.start();

    connection.on("LoadProducts", function () {
        LoadProdData();
    })
    LoadProdData();

    function LoadProdData() {
        var tr = '';
        $.ajax({
            url: '/Categories/GetCategories',
            method: 'GET',
            success: (result) => {
                $.each(result, (k, v) => {
                    tr +=
                        `<tr> 
                        <td> ${v.CategoryId}</td>
                        <td> ${v.CategoryName}</td>
                        <td> ${v.Description}</td>
                        <td>
                            <a href='../Products/Edit?id=${v.CategoryId}'>Edit</a> |
                            <a href='../Products/Details?id=${v.CategoryId}'>Details</a> |
                            <a href='../Products/Delete?id=${v.CategoryId}'>Delete</a> |
                        </td>
                    </tr>`
                })
                $("#tableBody").html(tr);
            },
            error: (error) => {
                console.log(error)
            }
        });
    }
})
