// App.js
import React, { useState } from 'react';
import toast, { Toaster } from 'react-pop-toast';
import axios from 'axios';

function App() {
  const [name, setName] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');
  const [id, setId] = useState('');
  const [retrievedDetails, setRetrievedDetails] = useState(null);

  const recordContactDetails = async () => {
    try {
      const response = await axios.post('https://localhost:7145/recordContactDetails', {
        Name: name,
        PhoneNumber: phoneNumber,
      });
      setId(response.data);
      toast(`Saved contact with ID number: ${response.data}`);
      setRetrievedDetails(null);
    } catch (error) {
      console.error('Error recording contact details:', error);
    }
  };

  const retrieveContactDetails = async () => {
    try {
      const response = await axios.get(`https://localhost:7145/retrieveContactDetails?id=${id}`);
      setRetrievedDetails(response.data);
    } catch (error) {
      console.error('Error retrieving contact details:', error);
    }
  };

  return (
    <div>
      <div> <h1>Contact Details Management</h1></div>
      <hr/>
      <div>
          <h2>Add Contact</h2>
          <label>Name: </label>
          <input type="text" value={name} onChange={(e) => setName(e.target.value)} />
      </div>
      <div>
        <label>Phone Number: </label>
        <input type="text" value={phoneNumber} onChange={(e) => setPhoneNumber(e.target.value)} />
      </div>
      <button onClick={recordContactDetails}>Save Contact Details</button>
      <Toaster />
      <br/><br/>
      <hr/>
      <div>
        <h2>Get Contact Details</h2>
        <label>Enter Contact ID: </label>
        <input type="text" onChange={(e) => setId(e.target.value)} />
      </div>
      <button onClick={retrieveContactDetails}>Retrieve Contact Details</button>
      {retrievedDetails && (
        <div>
          <h2>Retrieved Contact Details:</h2>
          <p>Name: {retrievedDetails.name}</p>
          <p>Phone Number: {retrievedDetails.phoneNumber}</p>
        </div>
      )}
    </div>
  );
}

export default App;
