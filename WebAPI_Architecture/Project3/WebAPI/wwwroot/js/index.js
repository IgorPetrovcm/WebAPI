function getIdElmentFromCollection(collection, text)
{
    for (element of collection)
    {
        if (element.id == text)
            return element.value;
    }
}


async function getAllUsers()
{
    const response = await fetch('api/Home/Get',{
        method: 'GET',
        headers: {'Accept': 'application/json'}
    })

    if (response.ok == true)
    {
        const users = await response.json();

        for (let user of users)
        {
            let p = document.createElement('p');
            p.innerText = `${user.name} ${user.age}`;

            getAll.appendChild(p);
        }
    }
}

async function getUser()
{
    const collection = getUserDiv.children;

    const id = getIdElmentFromCollection(collection, 'idInput');

    const response = await fetch(`api/Home/GetUser?id=${id}`,{
        method: 'GET',
        headers: {'Accept': 'application/json'}
    })

    if (response.ok == true)
    {
        const user = await response.json();

        let p = document.createElement('p');
        p.innerText = `${user.name} ${user.age}`;

        getUserDiv.appendChild(p);
    }
}


const getAllDiv = document.getElementById('getAll');
let buttonGetAll = getAllDiv.firstElementChild;
buttonGetAll.onclick = getAllUsers;

const getUserDiv = document.getElementById('getUser');
const buttonGetUser = getUserDiv.firstElementChild;
buttonGetUser.onclick = getUser;