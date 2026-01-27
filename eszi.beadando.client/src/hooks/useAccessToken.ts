import { useQuery } from "@tanstack/react-query";
import { axiosPrivate } from "../axios";

export const useAccessToken = () => {
  const { data: accessToken, isLoading } = useQuery({
    queryKey: ["cookietoken"],
    queryFn: async () => {
      try {
        var resp = await axiosPrivate.get<string>("/auth/cookietoken");
        return resp.data;
      } catch {
        return null;
      }
    },
  });

  return {
    accessToken,
    isLoading,
  };
};
