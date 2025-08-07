import { useState, useEffect} from "react"; //import means bring me information from somewhere else
import PizzaList from "./PizzaList";

const term = "Pizza";
const API_URL = '/pizzas';//the base endpoint for the API 
const headers = {
    'Content-Type': 'application/json' //this tells the server that we are sending JSON, common headers for POST/PUT/DELETE fetch request
};


function Pizza(){
    const [data, setData] = useState([]); //data is an array that holds the fetched list of pizzas
    const [error, setError] = useState(null); //error  holds any error messages, setError updates the error state

    const fetchPizzaData = () => { //uses fetch to call the /pizzas API Endpoint
        console.log('Fetching pizza data from API:', API_URL); //logs the API URL being called
        fetch(API_URL) //fetch is a built-in function to make HTTP requests, API_URL is the endpoint for the pizzas
        .then(response => response.json()) //response.json() converts the response to JSON format
        .then(data => setData(data)) //setData updates the data state with the received pizza data
        .catch(error => setError(error)); //if there is an error, setError updates the error state with the error message
    };

    useEffect(() => { //useEffect is a hook that runs the fetchPizzaData function when the component mounts
        fetchPizzaData(); //this function fetches the pizza data from the API when the component is first rendered
    }, []); // the empty array means it only runs once when first rendered

    const handleCreate = (item) => { //receives an item object containing name and description for the new pizza
        console.log(`add item: ${JSON.stringify(item)}`);

        fetch(API_URL,{
            method: 'POST', //POST METHOD is used to create a new resource on the server sending a request to /pizzas with the pizza data as json
            headers, //headers specify that we are sending JSON data
            body: JSON.stringify({ name: item.item,
            description: item.description}), //body is the data being sent to the server, it needs to be a string so we use JSON.stringify to convert the object to a JSON string
        })
            .then(response => response.json()) //convert the response to JSON
            .then(returnedItem => setData([...data, returnedItem])) //setData updates the data state by adding the newly created pizza to the existing list using the spread operator (...) to include all existing pizzas and appending the new one
            .catch(error => setError(error)); // if there is an error, setError updates the error state with the error message
    };

    //Receives an updatedItem object with updated pizza information, including an id.
    //Sends a PUT request to /pizzas/{id} to fully replace the pizza entry on the server.
    const handleUpdate = (updatedItem) => {
       console.log(`update item: ${JSON.stringify(updatedItem)}`);//logs the item being updated

       fetch(`${API_URL}/${updatedItem.id}`, { //sends a PUT request to /pizzas/{id} where {id} is the id of the pizza being updated
        method: 'PUT', //PUT method is used to update an existing resource on the server
        headers, //headers specify that we are sending JSON data
        body: JSON.stringify(
            { name: updatedItem.name,
                description: updatedItem.description
            }), //body contains the updated pizza data as a JSON string
       })
        .then(response => response.json()) //convert the response to JSON
        .then(returnedItem => { //returnedItem is the updated pizza data returned from the server
            const updatedData = data.map(pizza =>  pizza.id === returnedItem.id ? returnedItem : pizza //map over the existing data array to create a new array with the updated pizza
               //if the pizza id matches the returned item id, replace it with the returned item, otherwise keep the existing pizza
            );
            setData(updatedData); //setData updates the data state with the new array containing the updated pizza
        })
        .catch(error => setError(error)); //if there is an error, setError updates the error state with the error message
    };

    const handleDelete = (id) => {
        fetch(`${API_URL}/${id}`, { //sends a DELETE request to /pizzas/{id} where {id} is the id of the pizza being deleted
            method: 'DELETE', //DELETE method is used to remove a resource from the server
            headers, //headers specify that we are sending JSON data
        })
        .then(() => setData(data.filter(item => item.id !== id))) //setData updates the data state by filtering out the deleted pizza from the existing list
        .catch(error => console.error('Error deleting item:', error)); //if there is an error, log the error to the console
    };
    
    return (
    <div>
      <PizzaList
        name={term}
        data={data}
        error={error}
        onCreate={handleCreate}
        onUpdate={handleUpdate}
        onDelete={handleDelete}
      />
    </div>
  );
}
export default Pizza;
