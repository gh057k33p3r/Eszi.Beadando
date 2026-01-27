import { useQuery } from "@tanstack/react-query";
import { axiosPrivate } from "../../axios";
import { LoginForm } from "../LoginForm/LoginForm";
import { LogoutButton } from "../LogoutButton/LogoutButton";
import { Outlet } from "react-router";
import { Menu } from "../Menu/Menu";

export function Layout() {
  const { data: accessToken, isLoading } = useQuery({
    queryKey: ["cookietoken"],
    queryFn: () =>
      axiosPrivate.get<string>("/auth/cookietoken").then((resp) => resp.data),
  });

  return (
    <>
      {!isLoading ? (
        <>
          <div style={{ display: "flex", justifyContent: "space-between" }}>
            <div style={{ display: "flex", gap: 3 }}>
              <Menu />
            </div>
            <div style={{ display: "flex", gap: 3 }}>
              {!accessToken ? <LoginForm /> : <LogoutButton />}
            </div>
          </div>
          <Outlet />
        </>
      ) : null}
    </>
  );
}
