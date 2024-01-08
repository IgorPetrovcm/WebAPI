function getIdElementFromCollection(collection, text)
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
        const fromUsers_Div = document.getElementById('fromUsers');
        if (fromUsers_Div)
            getAll_Div.removeChild(fromUsers_Div);
        
        const users = await response.json();

        let divFromUsers = document.createElement('div');
        divFromUsers.id = 'fromUsers'
        
        for (let user of users)
        {
            let p = document.createElement('p');
            p.innerText = `${user.name} ${user.age}`;

            divFromUsers.appendChild(p);
        }
        
        getAll_Div.appendChild(divFromUsers);
    }
}

async function getUser()
{
    const collection = getUser_Div.children;

    const id = getIdElementFromCollection(collection, 'idInput');

    const response = await fetch(`api/Home/GetUser?id=${id}`,{
        method: 'GET',
        headers: {'Accept': 'application/json'}
    })

    if (response.ok == true)
    {
        const fromUser_Div = document.getElementById('fromUser');
        if (fromUser_Div)
            getUser_Div.removeChild(fromUser_Div);
        
        let divGetUser = document.createElement('div');
        divGetUser.id = 'fromUser';
        
        const user = await response.json();

        let p = document.createElement('p');
        p.innerText = `${user.name} ${user.age}`;
        
        divGetUser.appendChild(p);
        
        getUser_Div.appendChild(divGetUser);
    }
}

async function addUser()
{
    const response = await fetch('api/Home/Add',{
        method: 'POST',
        headers: {'Accept': 'application/json', 'Content-Type': 'application/json'},
        body: JSON.stringify({
            Name: getIdElementFromCollection(addUserDiv.children,'nameInput'),
            Age: getIdElementFromCollection(addUserDiv.children,'ageInput')
        })
    })
}

