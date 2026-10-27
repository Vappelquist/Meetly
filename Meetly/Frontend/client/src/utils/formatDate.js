export function formatDateTime(iso){
    if(!iso) return "";
    return new Date(iso).toLocaleString("sv-SE", {

        dateStyle: "short",
        timeStyle: "short",
    });
}