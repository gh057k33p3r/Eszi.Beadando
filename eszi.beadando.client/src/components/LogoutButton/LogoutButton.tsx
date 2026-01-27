import { useMutation, useQueryClient } from "@tanstack/react-query";
import { axiosPrivate } from "../../axios";

export function LogoutButton() {
  const { mutateAsync: logoutAsync } = useMutation({
    mutationFn: () =>
      axiosPrivate.post("/auth/logout").then((resp) => resp.data),
  });

  const queryClient = useQueryClient();

  return (
    <input
      type="button"
      value="Kilépés"
      onClick={async () => {
        logoutAsync().then(() => {
          queryClient.invalidateQueries();
        });
      }}
    />
  );
}
