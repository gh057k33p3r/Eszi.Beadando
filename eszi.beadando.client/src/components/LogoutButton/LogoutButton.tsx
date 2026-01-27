import { useMutation } from "@tanstack/react-query";
import { axiosPrivate } from "../../axios";

export function LogoutButton() {
  const { mutateAsync: logoutAsync } = useMutation({
    mutationFn: () =>
      axiosPrivate.post("/auth/logout").then((resp) => resp.data),
  });

  return (
    <input
      type="button"
      value="Kilépés"
      onClick={async () => {
        await logoutAsync();
        window.location.reload();
      }}
    />
  );
}
