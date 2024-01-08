const getAll_Div = document.getElementById('getAll');
let buttonGetAll = getAll_Div.firstElementChild;
buttonGetAll.onclick = getAllUsers;

const getUser_Div = document.getElementById('getUser');
const buttonGetUser = getUser_Div.firstElementChild;
buttonGetUser.onclick = getUser;

const addUser_Div = document.getElementById('addUser');
const buttonAddUser = addUser_Div.firstElementChild;
buttonAddUser.onclick = addUser;