const login = document.getElementById('login');

const password = document.getElementById('password')

const role = '';

document.getElementById('send').onclick = async function (){
    const response = await fetch('api/UserAuth/Register', {
        method: 'POST',
        headers: {'Accept': 'application/json', 'Content-Type': 'application/json'},
        body: JSON.stringify({
            Login: login.value,
            Password: password.value,
            Role: role
        })
    })
    if (response.ok == true)
    {
        window.location.href = 'http://localhost:5141/UserAuth/Login';
    }
}