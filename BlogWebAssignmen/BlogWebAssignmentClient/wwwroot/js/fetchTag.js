// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

async function getData() {
    //fetch fetch data from api
    await fetch("https://localhost:5001/api/Tag", {
        headers: {
            "Content-Type": "application/json"
        }, method: "get"
    }).then(res => res.json())
        .then(data => {
            displayCategory(data);
        })
        .catch(e => console.error(e));
}

async function displayCategory(data = []) {
    let tagListContainer = await document.querySelector(".tags-list");
    await data.forEach((item) => {
        let a = document.createElement("a");
        a.href = `/Home/OnGetPostByCategoryId/${item["id"]}`
        a.className = "link-dark custom-tags";
        a.innerHTML = `<span>${item["title"]}</span>`;
        tagListContainer.appendChild(a);
    })
}


getData();

// Write your JavaScript code.
