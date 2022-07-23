async function displayComment(data = []) {
    const commentTree = document.getElementById("commentTree");

    data.forEach((item) => {
        const commentNode = document.createElement("div");
        commentNode.className = "comment-node";
        commentNode.innerHTML = ` <div class="comment-node-header mb-3">
                        <div class="avatar ">
                            <img src="" alt="avatar">
                        </div>
                        <div class="info mx-3">
                            <div class="user">${item[""]}</div>
                            <div class="date-posted">20-07-2022</div>
                        </div>
                    </div>
                    <div class="comment-node-content">
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Alias aliquam animi culpa deleniti dolorum eius et, facere, fugit harum itaque numquam quis quo. Autem cum fugit omnis qui quidem temporibus!</p>
                    </div>
                    <div class="comment-node-action">
                        <button class="btn btn-light px-2 py-1">
                            <i class="fa-regular fa-heart"></i>
                        </button>
                        <button class="btn btn-light px-2 py-1">Reply</button>
                    </div>`
    })
}

