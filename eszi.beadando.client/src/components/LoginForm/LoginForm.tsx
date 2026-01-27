import { useMutation } from "@tanstack/react-query";
import { useState } from "react";
import { axiosPrivate } from "../../axios";

export function LoginForm() {
  const [email, setEmail] = useState<string>("admin");
  const [password, setPassword] = useState<string>("password");

  const { mutateAsync: loginAsync } = useMutation({
    mutationFn: () =>
      axiosPrivate
        .post("/auth/login", { email, password })
        .then((resp) => resp.data),
  });

  return (
    <div>
      <div>
        <input
          type="text"
          name="email"
          placeholder="E-mail cím"
          value={email}
          onChange={(e) => {
            setEmail(e.target.value);
          }}
        />
      </div>

      <div>
        <input
          type="password"
          name="password"
          placeholder="Jelszó"
          value={password}
          onChange={(e) => {
            setPassword(e.target.value);
          }}
        />
      </div>
      <div>
        <input
          type="button"
          value="Belépés"
          onClick={async () => {
            await loginAsync();
            window.location.reload();
          }}
        />
      </div>
    </div>
  );
}
