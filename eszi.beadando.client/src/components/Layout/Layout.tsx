import { useQuery } from "@tanstack/react-query";
import { axiosPrivate } from "../../axios";
import { LoginForm } from "../LoginForm/LoginForm";
import { LogoutButton } from "../LogoutButton/LogoutButton";

export function Layout({ children }: { children: React.ReactNode }) {
  const {
    data: accessToken,
    isLoading,
    isError,
  } = useQuery({
    queryKey: ["cookietoken"],
    queryFn: () =>
      axiosPrivate.get<string>("/auth/cookietoken").then((resp) => resp.data),
  });

  return (
    <>
      {!isLoading && !isError && accessToken ? (
        <>
          <LogoutButton />
          <div>{children}</div>
        </>
      ) : (
        <div>
          <LoginForm />
        </div>
      )}
    </>
  );
}
