using Discount.gRPC.Data;
using Discount.gRPC.Models;
using Discount.gRPC.Protos;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.gRPC.Services;

public class DiscountService(DiscountContext db) : DiscountProtoService.DiscountProtoServiceBase
{
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var coupon = await db.Coupons
           .FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

        if (coupon is null)
            throw new RpcException(new Status(StatusCode.NotFound, $"'{request.ProductName}' Coupon not found"));

        return coupon.Adapt<CouponModel>();
    }

    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<Coupon>();

        if (coupon is null)
            throw new RpcException(new Status(StatusCode.NotFound, " Invalide request"));

        await db.Coupons.AddAsync(coupon);

        await db.SaveChangesAsync();

        return coupon.Adapt<CouponModel>();
    }

    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var couponFromDb = await db.Coupons
            .FirstOrDefaultAsync(x => x.ProductName == request.Coupon.ProductName);

        if (couponFromDb is null)
            throw new RpcException(new Status(StatusCode.NotFound, $"'{request.Coupon.ProductName}' Coupon not found"));

        couponFromDb.ProductName    = request.Coupon.ProductName;
        couponFromDb.Description    = request.Coupon.Description;
        couponFromDb.Amount         = request.Coupon.Amount;

        await db.SaveChangesAsync();

        return new CouponModel
        {
            Id = couponFromDb.Id,
            ProductName = couponFromDb.ProductName,
            Description = couponFromDb.Description,
            Amount = couponFromDb.Amount
        };
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        var couponFromDb = await db.Coupons
            .FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

        if (couponFromDb is null)
            throw new RpcException(new Status(StatusCode.NotFound, $"'{request.ProductName}' Coupon not found"));

        db.Coupons.Remove(couponFromDb);

        await db.SaveChangesAsync();

        return new DeleteDiscountResponse { Success = true};
    }

}
