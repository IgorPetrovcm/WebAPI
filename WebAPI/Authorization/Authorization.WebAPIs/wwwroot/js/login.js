const login = document.getElementById('login');

const password = document.getElementById('password')

document.getElementById('send').onclick = async function(){
    const resposne = await fetch('api/UserAuth/Login',new {
        method: 'POST',
        headers: {'Accept': 'application/json', 'Content-Type': 'application/json'},
        body: JSON.stringify({
            Login: login,
            Password: password
        })
    });
    if (response.ok == true)
    {
        let data = await response.json(); 
        sessionStorage.setItem('tokenKey',data.token);
    }
}