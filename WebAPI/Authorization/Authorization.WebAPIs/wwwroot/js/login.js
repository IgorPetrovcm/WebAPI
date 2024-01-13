const login = document.getElementById('login');

const password = document.getElementById('password')

document.getElementById('send').onclick = async function(){
    const response = await fetch('http://localhost:5141/api/UserAuth/Login',{
        method: 'POST',
        headers: {'Accept': 'application/json', 'Content-Type': 'application/json'},
        body: JSON.stringify({
            Login: login.value,
            Password: password.value
        })
    })
    if (response.ok == true)
    {
        let data = await response.json(); 
        sessionStorage.setItem('tokenKey',data.token);
        
        window.location.href = 'http://localhost:5141/UserProfile/Profile';
    }
}