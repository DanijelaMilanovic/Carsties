import { pages } from "next/dist/build/templates/app-page"

export { auth as middleware } from "@/auth"

export const config = {
    matcher: [
        '/session'
    ],
    pages: {
        signIn: '/api/auth/signin'
    }
}