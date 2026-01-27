import { useNavigate } from "react-router";
import { menuItems } from "./menuItems";

export function Menu() {
  const navigate = useNavigate();

  return (
    <>
      {menuItems.map((mi, index) => (
        <div
          key={index}
          style={{ cursor: "pointer" }}
          onClick={() => {
            navigate(mi.url);
          }}
        >
          {mi.label}
        </div>
      ))}
    </>
  );
}
