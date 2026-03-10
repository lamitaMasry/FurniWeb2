import { getCart, clearCart } from "./cart-store.js";

async function postCheckout(payload) {
    const res = await fetch("/api/checkout", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(payload),
    });

    const text = await res.text();
    let data;
    try { data = JSON.parse(text); } catch { data = text; }

    if (!res.ok) {
        throw new Error(typeof data === "string" ? data : (data?.message ?? "Checkout failed"));
    }
    return data;
}

document.addEventListener("DOMContentLoaded", () => {
    const form = document.querySelector("#checkout-form");
    if (!form) return;

    form.addEventListener("submit", async (e) => {
        e.preventDefault();

        // ✅ block until required fields are filled
        if (!form.checkValidity()) {
            form.reportValidity();
            return;
        }

        const cart = getCart();
        if (!cart || cart.length === 0) {
            alert("Your cart is empty.");
            return;
        }

        const fd = new FormData(form);

        const payload = {
            firstName: String(fd.get("firstName") || "").trim(),
            lastName: String(fd.get("lastName") || "").trim(),
            email: String(fd.get("email") || "").trim(),
            phone: String(fd.get("phone") || "").trim(),
            country: String(fd.get("country") || "").trim(),
            address1: String(fd.get("address1") || "").trim(),
            address2: String(fd.get("address2") || "").trim() || null,
            state: String(fd.get("state") || "").trim(),
            zip: String(fd.get("zip") || "").trim(),
            orderNotes: String(fd.get("orderNotes") || "").trim() || null,
            items: cart.map(i => ({ productId: i.productId, quantity: i.quantity })),
        };

        try {
            const result = await postCheckout(payload);

            // ✅ clear cart after successful DB save
            clearCart();

            // ✅ go to thank you page
            window.location.href = "/thankyou.html?orderId=" + encodeURIComponent(result.orderId);
        } catch (err) {
            alert(err?.message || "Checkout failed");
        }
    });
});