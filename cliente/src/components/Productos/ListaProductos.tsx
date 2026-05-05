import { useState, useEffect } from 'react';
import axios from 'axios';
import { Producto } from './Producto';

export function ListaProductos() {
  const [productos, setProductos] = useState<Productos[]>([]);
  const [cargando, setCargando] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    axios.get<Productos[]>('http://localhost:5001/api/productos/listartodos')
      .then(response => {
        setProductos(response.data);
        setCargando(false);
      })
      .catch(error => {
        console.error(error);
        setError('Error al cargar los productos');
        setCargando(false);
      });
  }, []);

  if (cargando) return <p>Cargando productos...</p>;
  if (error) return <p className="alert alert-danger">{error}</p>;

  return (
    <ul className="list-group">
      {productos.map((producto, index) => (
        <Producto 
          key={index} 
          nombre={producto.nombre} 
          descripcion={producto.descripcion} 
        />
      ))}
    </ul>
  );
}
