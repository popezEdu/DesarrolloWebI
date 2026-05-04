import { useState, useEffect } from 'react'
import './App.css'
import axios from 'axios'

function App() {
  const [productos, setProductos] = useState<Productos[]>([])

  useEffect( () => {
    axios.get<Productos[]>('http://localhost:5001/api/productos/listartodos')
      .then(response => setProductos(response.data))
      .catch(error => console.error(error));
      return () => {}
  }, []);

  return (
    <>
      <h3>Lista de Productos</h3>
      <ul className="list-group">
        {productos.map((producto, index) => (
          <li key={index} className="list-group-item">
            <h5>{producto.nombre}</h5>
            <p>{producto.descripcion}</p>
          </li>
        ))}
      </ul>
    </>
  )
}

export default App
