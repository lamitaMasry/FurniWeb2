import { addToCart, cartCount } from "./cart-store.js";

function updateBadges() {
    document.querySelectorAll("[data-cart-count]").forEach(el => {
        el.textContent = String(cartCount());
    });
}

document.addEventListener("click", (e) => {
    const btn = e.target.closest(".js-add-to-cart");
    if (!btn) return;

    e.preventDefault();

    const productId = Number(btn.dataset.productId);
    if (!Number.isFinite(productId) || productId <= 0) {
        alert("Missing product id on this item.");
        return;
    }

    try {
        addToCart(productId, 1);
        updateBadges();
        // ✅ go to cart after adding
        window.location.href = "/cart.html";
    } catch (err) {
        alert(err?.message || "Failed to add to cart.");
    }
});

updateBadges();