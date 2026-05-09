export interface CreateLinkResponse {
  shortCode: string;
}

export interface GetLinkDetailsResponse {
  originalUrl: string;
  shortCode: string;
  clicks: number;
  createdAt: string;
}