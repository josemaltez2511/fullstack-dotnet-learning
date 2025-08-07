import { useState } from 'react';

function PizzaList({ name, data, onCreate, onUpdate, onDelete, error})
{
    //formData state holds the values for the pizza form
    const [formData, setFormData] = useState({id: '', name: '', description: ''});
   // editingId state holds the id of the pizza being edited or ir we are creating a new pizza
    const [editingId, setEditingId] = useState(null);

    const handleFormChange = (event) => {
        //updates formData state as the user types in the form
        //identifies the input field that has changed by its name attribute
        const { name, value } = event.target;
        setFormData(prevData => ({ //prevData is to ensure it uses the most recent state
            ...prevData, //this copies all existing data fields unchanged so its only the changed field that gets updated
            [name]: value   // updates only the field matching the inpus´s name to the new entered value
        }));
    };

    //this function is triggered when the form is submitted to create or update a pizza
    const handleSubmit = (event) => {
        //in ASP apps, the default behavior of a form submission is to reload the page
        //which we dont want because it would lose the current state (information) , we need to prevent that and process the data inside the app without reloading the page
        event.preventDefault(); //this prevents the default form submission behavior
        if (editingId){
            onUpdate(formData); //if editingId is set, we are updating an existing pizza
            setEditingId(null); //reset editingId to null after updating to stop editing mode and clear the form
        } else {
            onCreate(formData); //if editingId is not set, we are creating a new pizza
        }
        setFormData({id: '', name: '', description: ''}); //reset formData to clear the form after submission
    };

    const handleEdit = (pizzaItem) => { //pizzaItem is the pizza being edited, it contains properties like id, name, description
        setEditingId(pizzaItem.id); //to track that youre in editing mode for this specific pizza, differentiate between creating and editing an existing pizza
        setFormData({ //set formData to the values of the pizza being edited
            id: pizzaItem.id,
            name: pizzaItem.name,
            description: pizzaItem.description
        });
    }

    const handleCancelEdit = () => { //this function is called when the user clicks the cancel button while editing a pizza
        setEditingId(null); //reset editingId to null to stop editing mode
        setFormData({id: '', name: '', description: ''}); //reset formData to clear the form
    }; 

    return (
        <div>
      <h2>New {name}</h2>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          name="name"
          placeholder="Name"
          value={formData.name}
          onChange={handleFormChange}
        />
        <input
          type="text"
          name="description"
          placeholder="Description"
          value={formData.description}
          onChange={handleFormChange}
        />
        <button type="submit">{editingId ? 'Update' : 'Create'}</button>
        {editingId && <button type="button" onClick={handleCancelEdit}>Cancel</button>}
      </form>
      {error && <div>{error.message}</div>}
      <h2>{name}s</h2>
      <ul>
        {data.map(item => (
          <li key={item.id}>
            <div>{item.name} - {item.description}</div>
            <div><button onClick={() => handleEdit(item)}>Edit</button>
            <button onClick={() => onDelete(item.id)}>Delete</button></div>
          </li>
        ))}
      </ul>
    </div>
  );
}
export default PizzaList;
