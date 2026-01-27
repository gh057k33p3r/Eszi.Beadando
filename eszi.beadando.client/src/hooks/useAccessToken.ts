import { useQueryClient } from "@tanstack/react-query";

export const useAccessToken = () => {
  const queryClient = useQueryClient();

  const accessToken = queryClient.getQueryData<string>(["cookietoken"]);

  return {
    accessToken,
  };
};
