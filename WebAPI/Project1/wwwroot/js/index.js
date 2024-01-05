async function getUsers()
{
    let response = await fetch('api/user', {
        method: "GET",
        headers: {"Accept": "application/json"}
    })
    if (response.ok == true)
    {
        let users = await response.json()
        for (let user of users)
        {
            let p = document.createElement('p');
            p.innerText = user;

            document.body.appendChild(p);
        }
    }
}

document.getElementById('btn1').onclick = getUsers;