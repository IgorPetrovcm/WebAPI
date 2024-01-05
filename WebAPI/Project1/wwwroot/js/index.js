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
            p.innerText = `${user.name} ${user.age}`;

            document.getElementById('users').appendChild(p);
        }
    }
}

async function addUser()
{
    let nameUser = document.getElementById('inputName');
    let ageUser = document.getElementById('inputAge');

    const response = await fetch('api/user', {
        method: 'POST',
        headers: {'Accept': 'application/json', 'Content-Type': 'application/json'},
        body: JSON.stringify({
            Name: nameUser.value,
            Age: ageUser.value
        })
    })
    if (response.ok == true)
    {
        const user = await response.json();

        document.getElementById('users').appendChild(createPTag(user.Name,' ',user.Age));
    }
}
function createPTag(text)
{
    let p = document.createElement('p');
    p.innerText = text;
    return p;
}

document.getElementById('sendUser').onclick = addUser;

document.getElementById('btn1').onclick = getUsers;