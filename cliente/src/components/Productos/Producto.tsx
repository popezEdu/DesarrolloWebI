interface ProductoProps {
  nombre: string;
  descripcion: string;
}

export function Producto({ nombre, descripcion }: ProductoProps) {
  return (
    <li className="list-group-item">
      <h5>{nombre}</h5>
      <p>{descripcion}</p>
    </li>
  );
}
