
const todolist =[ {
   name: 'Make Dinner',
   Duedate: '2022-12-22'},
{
   name: 'Make Dinner',
   Duedate: '2022-12-22'
   }];

renderTodoList();
function renderTodoList(){
      let todoListHTML = ``;
      todolist.forEach((todoObject, index) => {
         const {name, Duedate} = todoObject;
         const html = `
         <div> ${name}</div>
         <div> ${Duedate}</div>
         <button onclick="
         todolist.splice(${index}, 1);
         renderTodoList();"
         class="delete-todo-button js-delete-todo-button"> Delete</button>
         `;
         todoListHTML += html;
      });
      
      document.querySelector('.js-todo-list').innerHTML = todoListHTML;

      document.querySelectorAll('.js-delete-todo-button')
      .forEach((deleteButton, index) => {
         deleteButton.addEventListener('click', () => {
         todoList.splice(index, 1);
         renderTodoList();
         });
      });   
}

      document.querySelector('.js-add-todo-button').addEventListener('click', () => {
           addTodo();
         });

function addTodo(){
   const inputElement =document.querySelector('.js-name-input');
   const name = inputElement.value;
   
   const dataInputElement =document.querySelector('.js-due-date-input');
   const Duedate = dataInputElement.value;

   console.log(name);
   todolist.push({
      // name: name,
      // Duedate: Duedate
      name, 
      Duedate //Shorthand property
   });
   console.log(todolist);
   renderTodoList();
   inputElement.value= '';

}