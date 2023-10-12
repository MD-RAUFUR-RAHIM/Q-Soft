
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
      for(let i=0; i<todolist.length; i++)
      {
         const todoObject = todolist[i];
         // const name = todoObject.name;
         // const Duedate = todoObject.Duedate;
         const {name, Duedate} = todoObject;
         const html = `
         <div> ${name}</div>
         <div> ${Duedate}</div>
         <button onclick="
         todolist.splice(${i}, 1);
         renderTodoList();"
         class="delete-todo-button"> Delete</button>
         `;
         todoListHTML += html;
      }
      
      console.log(todoListHTML);
      document.querySelector('.js-todo-list').innerHTML = todoListHTML;
}


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