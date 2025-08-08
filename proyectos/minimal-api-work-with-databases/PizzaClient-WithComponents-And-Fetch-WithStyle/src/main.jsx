// src/main.jsx (sanity check)
import React from 'react'
import ReactDOM from 'react-dom/client'

console.log('main.jsx loaded')

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <div style={{padding: 20, fontFamily: 'sans-serif'}}>
      <h1>Frontend sanity check</h1>
      <p>If you see this, Vite & index.html are OK.</p>
    </div>
  </React.StrictMode>
)
