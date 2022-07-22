// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
const apiCategory = "https://localhost:5001/api/Category";

async function getData() {
    await fetch(apiCategory, {
        headers: {
            "Content-Type": "application/json"
        }, method: "get"
    }).then(res => res.json())
        .then(data => displayCategory(data))
        .catch(e => console.error(e));
}

async function displayCategory(data = []) {
    let tagListContainer = await document.querySelector(".tags-list");
    await data.forEach((item) => {
        let a = document.createElement("a");
        a.href = "https://www.google.com";
        a.className = "link-dark custom-tags";
        a.innerHTML = `<span>${item["title"]}</span>`;
        tagListContainer.appendChild(a);
    })
}

getData();

// Write your JavaScript code.
